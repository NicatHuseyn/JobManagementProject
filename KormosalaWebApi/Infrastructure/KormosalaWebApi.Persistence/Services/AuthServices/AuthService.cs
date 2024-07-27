using Google.Apis.Auth;
using KormosalaWebApi.Application.Abstractions.Services.AuthServices;
using KormosalaWebApi.Application.Abstractions.Services.MailServices;
using KormosalaWebApi.Application.Abstractions.Services.UserServices;
using KormosalaWebApi.Application.Abstractions.Token;
using KormosalaWebApi.Application.DTOs.LoginDtos;
using KormosalaWebApi.Application.DTOs.TokenDtos;
using KormosalaWebApi.Application.Helpers;
using KormosalaWebApi.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Persistence.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserService _userService;
        private readonly IMailService _mailService;

        public AuthService(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IConfiguration configuration, SignInManager<AppUser> signInManager, IUserService userService, IMailService mailService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
            _signInManager = signInManager;
            _userService = userService;
            _mailService = mailService;
        }

        public async Task<Token> GoogleLoginAsync(string credential)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { "303036556064-nvp9b5mk124reoqgta6ncmg7j5p7915s.apps.googleusercontent.com" }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(credential,settings);

            var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");

            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            if (user is null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);

                if (user is null)
                {
                    user = new AppUser
                    {
                        Email = payload.Email,
                        UserName = payload.Email,
                        FullName = payload.Name
                    };

                    IdentityResult result = await _userManager.CreateAsync(user);

                    if (!result.Succeeded)
                    {
                        throw new Exception("Could not create user");
                    }
                }

                IdentityResult addLoginResult = await _userManager.AddLoginAsync(user, info);

                if (!addLoginResult.Succeeded)
                {
                    throw new Exception("Invariant external authentication.");
                }
            }

            Token token = _tokenHandler.CreateAccessToken(user);
            await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 5);
            return token;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.UserNameOrEmail) ?? await _userManager.FindByEmailAsync(loginRequest.UserNameOrEmail);

            if (user is null)
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = "Check your username"
                };
            }

            try
            {
                SignInResult result = await _signInManager.CheckPasswordSignInAsync(user,loginRequest.Password,false);

                if (result.Succeeded)
                {
                    Token token = _tokenHandler.CreateAccessToken(user);
                    await _userService.UpdateRefreshTokenAsync(token.RefreshToken,user,token.Expiration,1);
                    return new LoginResponseDto
                    {
                        Success = true,
                        Message = "Successfully",
                        Token = token
                    };
                }
                else
                {
                    return new LoginResponseDto
                    {
                        Success = false,
                        Message = "Check your password",
                        Token = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new LoginResponseDto
                {
                    Success = false,
                    Message = ex.Message,
                    Token = null
                };
            }
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u=>u.RefreshToken == refreshToken);

            if (user is { } && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken,user,token.Expiration, 15);
                return token;
            }
            throw new Exception("Not Found User");
        }

        public async Task PasswordResetAsync(string email)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);

            if (user is not null)  
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                CustomEncoders.UrlEncode(resetToken);

                await _mailService.SendPasswordResetMailAsync(user.Email,user.Id,resetToken);
            }
        }

        public async Task<bool> VerifyResetToken(string resetToken, string userId)
        {
            AppUser user =  await _userManager.FindByIdAsync(userId);

            if (user is not null)
            {
                //byte[] tokenBytes = WebEncoders.Base64UrlDecode(resetToken);
                //Encoding.UTF8.GetString(tokenBytes);

                CustomEncoders.UrlEncode(resetToken);

                return await _userManager.VerifyUserTokenAsync(user,_userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword",resetToken);
            }

            return false;
        }
    }
}

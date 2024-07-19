using Google.Apis.Auth;
using KormosalaWebApi.Application.Abstractions.Services.AuthServices;
using KormosalaWebApi.Application.Abstractions.Services.UserServices;
using KormosalaWebApi.Application.Abstractions.Token;
using KormosalaWebApi.Application.DTOs.LoginDtos;
using KormosalaWebApi.Application.DTOs.TokenDtos;
using KormosalaWebApi.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
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

        public AuthService(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IConfiguration configuration, SignInManager<AppUser> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
            _signInManager = signInManager;
            _userService = userService;
        }

        public async Task<Token> GoogleLoginAsync(string credential)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { _configuration["Google:Client_Id"] }
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

            Token token = _tokenHandler.CreateAccessToken();
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
                    Token token = _tokenHandler.CreateAccessToken();
                    await _userService.UpdateRefreshTokenAsync(token.RefreshToken,user,token.Expiration,5);
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
    }
}

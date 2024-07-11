using KormosalaWebApi.Application.Abstractions.Token;
using KormosalaWebApi.Application.DTOs.TokenDtos;
using KormosalaWebApi.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.UserCommands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;


        public LoginUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserNameOrEmail)?? await _userManager.FindByEmailAsync(request.UserNameOrEmail);

            if (user is null)
            {
                return new LoginUserCommandResponse
                {
                    Success = false,
                    Message = "Check your username"
                };
            }

            try
            {
                SignInResult result = await _signInManager.CheckPasswordSignInAsync(user,request.Password,false);

                if (result.Succeeded)
                {
                    Token token = _tokenHandler.CreateAccessToken();
                    return new LoginUserCommandResponse
                    {
                        Token = token,
                        Success = true,
                        Message = "Success token"
                    };
                }
                else
                {
                    return new LoginUserCommandResponse
                    {
                        Success = false,
                        Message = "Check your password"
                    };
                }
            }
            catch (Exception ex)
            {
                return new LoginUserCommandResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}

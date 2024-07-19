using KormosalaWebApi.Application.Abstractions.Services.AuthServices;
using KormosalaWebApi.Application.Abstractions.Token;
using KormosalaWebApi.Application.DTOs.LoginDtos;
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
        private readonly IInternalAuthentication _internalAuthentication;

        public LoginUserCommandHandler(IInternalAuthentication internalAuthentication)
        {
            _internalAuthentication = internalAuthentication;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            LoginResponseDto response = await _internalAuthentication.LoginAsync(new DTOs.LoginDtos.LoginRequestDto
            {
                UserNameOrEmail = request.UserNameOrEmail,
                Password = request.Password
            });

            return new LoginUserCommandResponse
            {
                Message = response.Message,
                Success = response.Success,
                Token = response.Token
            };
        }
    }
}

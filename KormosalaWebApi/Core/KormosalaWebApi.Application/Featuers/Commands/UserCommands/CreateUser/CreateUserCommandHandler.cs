using KormosalaWebApi.Application.Abstractions.Services.UserServices;
using KormosalaWebApi.Application.DTOs.UserDtos;
using KormosalaWebApi.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.UserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponseDto response = await _userService.CreateAsync(new()
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
            });

            return new()
            {
                Message = response.Message,
                Success = response.Success,
            };
        }
    }
}

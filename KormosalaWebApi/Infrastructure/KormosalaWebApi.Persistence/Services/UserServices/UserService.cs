using KormosalaWebApi.Application.Abstractions.Services.UserServices;
using KormosalaWebApi.Application.DTOs.UserDtos;
using KormosalaWebApi.Application.Exceptions;
using KormosalaWebApi.Application.Featuers.Commands.UserCommands.CreateUser;
using KormosalaWebApi.Application.Helpers;
using KormosalaWebApi.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Persistence.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponseDto> CreateAsync(CreateUserDto createUser)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                FullName = createUser.FullName,
                UserName = createUser.UserName,
                Email = createUser.Email,
            },createUser.Password);

            // String Builder for error messages
            StringBuilder sb = new StringBuilder();

            if (result.Succeeded)
            {
                return new CreateUserResponseDto
                {
                    Success = true,
                    Message = "Create User Successfully"
                };
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    sb.AppendLine($"Code:{error.Code} Message:{error.Description}");
                }
                return new CreateUserResponseDto
                {
                    Success = false,
                    Message = sb.ToString()
                };
            }

        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {

            if (user is not null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddMinutes(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new Exception("User Not Found");
            }
        }

        public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);

            if (user is not null)
            {
                resetToken = CustomEncoders.UrlDecode(resetToken);
                IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);

                if (result.Succeeded)
                    await _userManager.UpdateSecurityStampAsync(user);
                else
                    throw new PasswordChangeFIeldException();
                
            }
        }
    }
}

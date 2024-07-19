using KormosalaWebApi.Application.DTOs.UserDtos;
using KormosalaWebApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Abstractions.Services.UserServices
{
    public interface IUserService
    {
        Task<CreateUserResponseDto> CreateAsync(CreateUserDto createUser);
        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}

using KormosalaWebApi.Application.DTOs.LoginDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Abstractions.Services.AuthServices
{
    public interface IInternalAuthentication
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequest);
    }
}

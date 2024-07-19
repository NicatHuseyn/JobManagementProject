using KormosalaWebApi.Application.DTOs.TokenDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Abstractions.Services.AuthServices
{
    public interface IExternalAuthentication
    {
        Task<DTOs.TokenDtos.Token> GoogleLoginAsync(string credential);
    }
}

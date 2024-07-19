using KormosalaWebApi.Application.DTOs.TokenDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.DTOs.LoginDtos
{
    public class LoginResponseDto
    {
        public Token Token { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

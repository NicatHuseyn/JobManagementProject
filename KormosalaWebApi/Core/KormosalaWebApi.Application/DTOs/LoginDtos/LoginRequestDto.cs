using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.DTOs.LoginDtos
{
    public class LoginRequestDto
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}

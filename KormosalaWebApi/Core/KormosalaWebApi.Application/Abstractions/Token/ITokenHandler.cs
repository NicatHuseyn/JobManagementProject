using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.TokenDtos.Token CreateAccessToken();
    }
}

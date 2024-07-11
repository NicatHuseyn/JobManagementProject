using KormosalaWebApi.Application.Abstractions.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.DTOs.TokenDtos.Token CreateAccessToken()
        {
            Application.DTOs.TokenDtos.Token token = new();

            // Create Security key
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha256);


            token.Expiration = DateTime.UtcNow.AddMinutes(5);
            JwtSecurityToken jwtSecurityToken = new(audience: _configuration["Token:Auidence"], issuer: _configuration["Token:Issure"], expires: token.Expiration, notBefore: DateTime.UtcNow, signingCredentials: signingCredentials);


            // Token creator
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);

            return token;

        }
    }
}

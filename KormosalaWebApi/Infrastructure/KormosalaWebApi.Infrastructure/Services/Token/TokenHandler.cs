﻿using KormosalaWebApi.Application.Abstractions.Token;
using KormosalaWebApi.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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

        public Application.DTOs.TokenDtos.Token CreateAccessToken(AppUser appUser)
        {
            Application.DTOs.TokenDtos.Token token = new();

            // Create Security key
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha256);


            token.Expiration = DateTime.UtcNow.AddMinutes(1);
            JwtSecurityToken jwtSecurityToken = new(
                audience: _configuration["Token:Auidence"], 
                issuer: _configuration["Token:Issure"], 
                expires: token.Expiration, 
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                claims: new List<Claim> { new Claim(ClaimTypes.Name, appUser.UserName)}
                );


            // Token creator
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);

            // create refresh token
            token.RefreshToken = CreateRefreshToken();

            return token;

        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}

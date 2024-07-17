using Google.Apis.Auth;
using KormosalaWebApi.Application.Abstractions.Token;
using KormosalaWebApi.Application.DTOs.TokenDtos;
using KormosalaWebApi.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.UserCommands.GooleLogin
{
    public class GooleLoginCommandHandler : IRequestHandler<GooleLoginCommandRequest, GooleLoginCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;

        public GooleLoginCommandHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<GooleLoginCommandResponse> Handle(GooleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { "303036556064-nvp9b5mk124reoqgta6ncmg7j5p7915s.apps.googleusercontent.com" }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(request.Credential, settings);

            var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");

            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            bool result = user != null;

            if (user is null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);

                if (user is null)
                {
                    user = new AppUser
                    {
                        Email = payload.Email,
                        UserName = payload.Email, 
                        FullName = payload.Name
                    };

                    IdentityResult identityResult = await _userManager.CreateAsync(user);

                    if (!identityResult.Succeeded)
                    {
                        throw new Exception("Could not create user");
                    }
                }

                IdentityResult addLoginResult = await _userManager.AddLoginAsync(user, info);
                if (!addLoginResult.Succeeded)
                {
                    throw new Exception("Invariant external authentication.");
                }
                else
                {
                    throw new Exception("Invariant external authentication.");
                }
            }

            Token token = _tokenHandler.CreateAccessToken();

            return new GooleLoginCommandResponse
            {
                Token = token
            };
        }
    }
}

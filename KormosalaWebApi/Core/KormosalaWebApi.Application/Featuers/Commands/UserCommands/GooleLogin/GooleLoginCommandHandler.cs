   using Google.Apis.Auth;
using KormosalaWebApi.Application.Abstractions.Services.AuthServices;
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
        private readonly IExternalAuthentication _externalAuthentication;

        public GooleLoginCommandHandler(IExternalAuthentication externalAuthentication)
        {
            _externalAuthentication = externalAuthentication;
        }

        public async Task<GooleLoginCommandResponse> Handle(GooleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            Token token = await _externalAuthentication.GoogleLoginAsync(request.Credential);

            return new GooleLoginCommandResponse
            {
                Token = token,
            };
        }
    }
}

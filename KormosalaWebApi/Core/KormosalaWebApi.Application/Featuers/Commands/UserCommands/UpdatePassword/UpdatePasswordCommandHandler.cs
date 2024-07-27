using KormosalaWebApi.Application.Abstractions.Services.UserServices;
using KormosalaWebApi.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.UserCommands.UpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommandRequest, UpdatePasswordCommandResponse>
    {
        private readonly IUserService _userService;

        public UpdatePasswordCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            if (!request.Password.Equals(request.ConfirmPassword))
                throw new PasswordChangeFIeldException("Sifreni duzgun dogrulayin");

            await _userService.UpdatePasswordAsync(request.UserId, request.ResetToken, request.Password);

            return new UpdatePasswordCommandResponse();
        }
    }
}

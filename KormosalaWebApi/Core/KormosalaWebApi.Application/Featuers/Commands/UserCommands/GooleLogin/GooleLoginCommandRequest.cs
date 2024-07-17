using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.UserCommands.GooleLogin
{
    public class GooleLoginCommandRequest:IRequest<GooleLoginCommandResponse>
    {
        public string ClientId { get; set; }
        public string Credential { get; set; }
    }
}

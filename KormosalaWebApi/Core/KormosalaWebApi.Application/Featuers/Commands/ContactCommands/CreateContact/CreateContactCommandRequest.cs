using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.ContactCommands.CreateContact
{
    public class CreateContactCommandRequest:IRequest<CreateContactCommandResponse>
    {
        public string FullName { get; set; }
        public string UserMessage { get; set; }
        public string Email { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.ContactCommands.RemoveContact
{
    public class RemoveContactCommandRequest:IRequest<RemoveContactCommandResponse>
    {
        public int Id { get; set; }
    }
}

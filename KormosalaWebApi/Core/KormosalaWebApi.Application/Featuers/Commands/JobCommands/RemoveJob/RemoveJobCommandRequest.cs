using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.JobCommands.RemoveJob
{
    public class RemoveJobCommandRequest:IRequest<RemoveJobCommandResponse>
    {
        public int Id { get; set; }
    }
}

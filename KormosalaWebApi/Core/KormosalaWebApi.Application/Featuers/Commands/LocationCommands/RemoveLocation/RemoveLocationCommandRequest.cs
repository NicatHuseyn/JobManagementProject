using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.LocationCommands.RemoveLocation
{
    public class RemoveLocationCommandRequest:IRequest<RemoveLocationCommandResponse>
    {
        public int Id { get; set; }
    }
}

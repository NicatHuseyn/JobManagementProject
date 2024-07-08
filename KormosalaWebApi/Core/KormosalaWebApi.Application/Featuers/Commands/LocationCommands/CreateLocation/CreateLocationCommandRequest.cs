using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.LocationCommands.CreateLocation
{
    public class CreateLocationCommandRequest:IRequest<CreateLocationCommandResponse>
    {
        public string AddressName { get; set; }
        public int CompanyId { get; set; }
    }
}

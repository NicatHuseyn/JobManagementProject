using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.LocationCommands.UpdateLocation
{
    public class UpdateLocationCommandRequest:IRequest<UpdateLocationCommandResponse>
    {
        public int Id { get; set; }
        public string AddressName { get; set; }
        public int CompanyId { get; set; }
    }
}

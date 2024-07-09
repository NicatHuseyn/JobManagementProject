using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.IndustryCommands.UpdateIndustry
{
    public class UpdateIndustryCommandRequest:IRequest<UpdateIndustryCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

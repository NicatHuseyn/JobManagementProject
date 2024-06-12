using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.IndustryCommands.CreateIndustry
{
    public class CreateIndustryCommandRequest:IRequest<CreateIndustryCommandResponse>
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}

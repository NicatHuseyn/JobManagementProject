using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.IndustryCommands.RemoveIndustry
{
    public class RemoveIndustryCommandRequest:IRequest<RemoveIndustryCommandResponse>
    {
        public int Id { get; set; }
    }
}

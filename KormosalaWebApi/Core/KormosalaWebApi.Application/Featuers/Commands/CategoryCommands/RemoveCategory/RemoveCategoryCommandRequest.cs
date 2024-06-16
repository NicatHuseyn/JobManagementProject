using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.CategoryCommands.RemoveCategroy
{
    public class RemoveCategoryCommandRequest:IRequest<RemoveCategoryCommandResponse>
    {
        public int Id { get; set; }
    }
}

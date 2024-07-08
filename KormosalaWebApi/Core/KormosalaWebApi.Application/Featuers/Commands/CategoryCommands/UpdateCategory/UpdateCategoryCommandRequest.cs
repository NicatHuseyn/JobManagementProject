using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommandRequest:IRequest<UpdateCategoryCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

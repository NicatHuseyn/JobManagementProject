using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.BlogCommands.RemoveBlog
{
    public class RemoveBlogCommandRequest:IRequest<RemoveBlogCommandResponse>
    {
        public int Id { get; set; }
    }
}

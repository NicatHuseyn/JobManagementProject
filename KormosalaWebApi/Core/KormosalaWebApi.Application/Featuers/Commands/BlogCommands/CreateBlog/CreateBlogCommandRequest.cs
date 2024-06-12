using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Commands.BlogCommands.CreateBlog
{
    public class CreateBlogCommandRequest:IRequest<CreateBlogCommandResponse>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
    }
}

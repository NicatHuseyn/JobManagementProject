using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.BlogQueries.GetByIdBlog
{
    public class GetByIdBlogQueryRequest:IRequest<GetByIdBlogQueryResponse>
    {
        public int Id { get; set; }
    }
}

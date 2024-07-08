using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.JobQueries.GetByIdJob
{
    public class GetByIdJobQueryRequest:IRequest<GetByIdJobQueryResponse>
    {
        public int Id { get; set; }
    }
}

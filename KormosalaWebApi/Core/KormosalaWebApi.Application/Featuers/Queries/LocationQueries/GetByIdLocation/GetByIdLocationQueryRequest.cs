using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.LocationQueries.GetByIdLocation
{
    public class GetByIdLocationQueryRequest:IRequest<GetByIdLocationQueryResponse>
    {
        public int Id { get; set; }
    }
}

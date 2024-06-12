using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.IndustryQueries.GetByIdIndustry
{
    public class GetByIdIndustryQueryRequest:IRequest<GetByIdIndustryQueryResponse>
    {
        public int Id { get; set; }
    }
}

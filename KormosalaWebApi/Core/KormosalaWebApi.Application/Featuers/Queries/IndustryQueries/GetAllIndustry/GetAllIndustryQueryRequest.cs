using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.IndustryQueries.GetAllIndustry
{
    public class GetAllIndustryQueryRequest:IRequest<List<GetAllIndustryQueryResponse>>
    {
    }
}

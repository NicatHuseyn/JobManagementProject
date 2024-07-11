using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.JobQueries.GetJobCategoryAndCompany
{
    public class GetJobCategoryAndCompanyQueryRequest:IRequest<List<GetJobCategoryAndCompanyQueryResponse>>
    {
    }
}

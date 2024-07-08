using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.CompanyQueries.GetByIdCompany
{
    public class GetByIdCompanyQueryRequest:IRequest<GetByIdCompanyQueryResponse>
    {
        public int Id { get; set; }
    }
}

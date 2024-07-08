using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.ContactQueries.GetByIdContact
{
    public class GetByIdContactQueryRequest:IRequest<GetByIdContactQueryResponse>
    {
        public int Id { get; set; }
    }
}

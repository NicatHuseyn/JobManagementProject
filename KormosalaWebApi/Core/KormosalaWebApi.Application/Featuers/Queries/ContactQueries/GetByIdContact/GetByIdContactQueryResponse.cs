using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.ContactQueries.GetByIdContact
{
    public class GetByIdContactQueryResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserMessage { get; set; }
        public string Email { get; set; }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

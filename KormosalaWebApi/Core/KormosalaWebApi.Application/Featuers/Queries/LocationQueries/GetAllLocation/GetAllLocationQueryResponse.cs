using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.LocationQueries.GetAllLocation
{
    public class GetAllLocationQueryResponse
    {
        public int Id { get; set; }
        public string AddressName { get; set; }
        public int CompanyId { get; set; }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

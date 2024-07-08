using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.CompanyQueries.GetByIdCompany
{
    public class GetByIdCompanyQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string WebSiteUrl { get; set; }
        public string Email { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

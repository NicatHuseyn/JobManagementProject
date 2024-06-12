using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.IndustryQueries.GetAllIndustry
{
    public class GetAllIndustryQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

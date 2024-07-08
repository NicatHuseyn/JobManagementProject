using KormosalaWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.JobQueries.GetByIdJob
{
    public class GetByIdJobQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Salary { get; set; }
        public int Experince { get; set; }

        public string JobType { get; set; }

        public int CategoryId { get; set; }

        public int CompanyId { get; set; }

        public bool Sucess { get; set; }
        public string Message { get; set; }
    }
}

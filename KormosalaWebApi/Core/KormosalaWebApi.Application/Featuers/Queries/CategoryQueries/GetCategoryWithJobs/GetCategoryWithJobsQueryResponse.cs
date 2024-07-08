using KormosalaWebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Featuers.Queries.CategoryQueries.GetCategoryWithJobs
{
    public class GetCategoryWithJobsQueryResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}

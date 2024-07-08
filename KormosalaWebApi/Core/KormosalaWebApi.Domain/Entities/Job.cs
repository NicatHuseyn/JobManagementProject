using KormosalaWebApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Domain.Entities
{
    
    public class Job:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Salary { get; set; }
        public int Experince { get; set; }
        public int AppliedCount { get; set; }
        public bool isNew { get; set; }
        public int ViewCount { get; set; }

        public string JobType { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public Company Company { get; set; }
        public int CompanyId { get; set; }

    }
}

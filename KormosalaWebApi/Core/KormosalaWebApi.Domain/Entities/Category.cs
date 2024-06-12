using KormosalaWebApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }

        public ICollection<Job> Jobs { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}

using KormosalaWebApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Domain.Entities
{
    public class Company:BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string WebSiteUrl { get; set; }
        public string Email { get; set; }

        public ICollection<Location> Locations { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}

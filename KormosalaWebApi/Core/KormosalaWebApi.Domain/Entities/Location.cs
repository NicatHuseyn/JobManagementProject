using KormosalaWebApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Domain.Entities
{
    public class Location:BaseEntity
    {
        public string AddressName { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}

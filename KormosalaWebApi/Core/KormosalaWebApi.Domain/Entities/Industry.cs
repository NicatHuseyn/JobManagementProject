using KormosalaWebApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Domain.Entities
{
    public class Industry:BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}

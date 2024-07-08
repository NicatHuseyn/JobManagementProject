using KormosalaWebApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Domain.Entities
{
    public class Contact:BaseEntity
    {
        public string FullName { get; set; }
        public string UserMessage { get; set; }
        public string Email { get; set; }
    }
}

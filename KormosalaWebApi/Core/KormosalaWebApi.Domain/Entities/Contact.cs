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
        public string EmailAddress { get; set; }
        public string Message { get; set; }
        public string ContactInformation { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}

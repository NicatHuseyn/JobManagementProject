using KormosalaWebApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Domain.Entities
{
    public class Blog:BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}

using KormosalaWebApi.Application.Repositories.BlogRepository;
using KormosalaWebApi.Domain.Entities;
using KormosalaWebApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Persistence.Repositories.BlogRepository
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public BlogRepository(KormosalaDbContext context) : base(context)
        {
        }
    }
}

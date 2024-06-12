using KormosalaWebApi.Application.Repositories.IndustryRepository;
using KormosalaWebApi.Domain.Entities;
using KormosalaWebApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Persistence.Repositories.IndustryRepository
{
    public class IndustryRepository : Repository<Industry>, IIndustryRepository
    {
        public IndustryRepository(KormosalaDbContext context) : base(context)
        {
        }
    }
}

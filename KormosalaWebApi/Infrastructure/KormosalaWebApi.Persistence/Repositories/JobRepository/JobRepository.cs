using KormosalaWebApi.Application.Repositories.JobRepository;
using KormosalaWebApi.Domain.Entities;
using KormosalaWebApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Persistence.Repositories.JobRepository
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(KormosalaDbContext context) : base(context)
        {
        }
    }
}

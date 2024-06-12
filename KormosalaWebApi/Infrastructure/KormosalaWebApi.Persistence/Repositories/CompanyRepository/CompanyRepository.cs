using KormosalaWebApi.Application.Repositories.CompnayRepository;
using KormosalaWebApi.Domain.Entities;
using KormosalaWebApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Persistence.Repositories.CompanyRepository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(KormosalaDbContext context) : base(context)
        {
        }
    }
}

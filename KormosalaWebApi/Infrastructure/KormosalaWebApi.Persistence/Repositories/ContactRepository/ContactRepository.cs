using KormosalaWebApi.Application.Repositories.ContactRepository;
using KormosalaWebApi.Domain.Entities;
using KormosalaWebApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Persistence.Repositories.ContactRepository
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(KormosalaDbContext context) : base(context)
        {
        }
    }
}

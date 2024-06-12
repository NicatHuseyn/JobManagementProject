using KormosalaWebApi.Application.Repositories.LocationRepository;
using KormosalaWebApi.Domain.Entities;
using KormosalaWebApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Persistence.Repositories.LocationRepository
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(KormosalaDbContext context) : base(context)
        {
        }
    }
}

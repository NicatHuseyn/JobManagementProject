using KormosalaWebApi.Application.Repositories.BlogRepository;
using KormosalaWebApi.Application.Repositories.CategoryRepository;
using KormosalaWebApi.Application.Repositories.IndustryRepository;
using KormosalaWebApi.Persistence.Contexts;
using KormosalaWebApi.Persistence.Repositories.BlogRepository;
using KormosalaWebApi.Persistence.Repositories.CategoryRepository;
using KormosalaWebApi.Persistence.Repositories.IndustryRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<KormosalaDbContext>(options=>options.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<IBlogRepository,BlogRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IIndustryRepository,IndustryRepository>();
        }
    }
}

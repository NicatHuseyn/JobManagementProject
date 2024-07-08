using KormosalaWebApi.Application.Interfaces.CategoryInterfaces;
using KormosalaWebApi.Application.Repositories.BlogRepository;
using KormosalaWebApi.Application.Repositories.CategoryRepository;
using KormosalaWebApi.Application.Repositories.CompnayRepository;
using KormosalaWebApi.Application.Repositories.ContactRepository;
using KormosalaWebApi.Application.Repositories.IndustryRepository;
using KormosalaWebApi.Application.Repositories.JobRepository;
using KormosalaWebApi.Application.Repositories.LocationRepository;
using KormosalaWebApi.Persistence.Abstractions;
using KormosalaWebApi.Persistence.Abstractions.CategoryAbstraction;
using KormosalaWebApi.Persistence.Contexts;
using KormosalaWebApi.Persistence.Repositories.BlogRepository;
using KormosalaWebApi.Persistence.Repositories.CategoryRepository;
using KormosalaWebApi.Persistence.Repositories.CompanyRepository;
using KormosalaWebApi.Persistence.Repositories.ContactRepository;
using KormosalaWebApi.Persistence.Repositories.IndustryRepository;
using KormosalaWebApi.Persistence.Repositories.JobRepository;
using KormosalaWebApi.Persistence.Repositories.LocationRepository;
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
            services.AddScoped<ICompanyRepository,CompanyRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ILocationRepository,LocationRepository>();
            services.AddScoped<IJobRepository,JobRepository>();
            services.AddScoped<ICategoryWithJobs,CategoryWithJobs>();
        }
    }
}

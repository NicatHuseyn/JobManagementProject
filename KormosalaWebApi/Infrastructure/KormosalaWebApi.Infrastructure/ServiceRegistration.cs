using KormosalaWebApi.Application.Services.FileService;
using KormosalaWebApi.Infrastructure.Services.FileService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
        }
    }
}

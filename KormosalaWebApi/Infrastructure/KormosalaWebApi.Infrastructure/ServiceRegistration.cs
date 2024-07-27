using KormosalaWebApi.Application.Abstractions.Services.ConfigurationServices;
using KormosalaWebApi.Application.Abstractions.Services.MailServices;
using KormosalaWebApi.Application.Abstractions.Token;
using KormosalaWebApi.Application.Services.FileService;
using KormosalaWebApi.Infrastructure.Services.ConfigurationServices;
using KormosalaWebApi.Infrastructure.Services.FileService;
using KormosalaWebApi.Infrastructure.Services.MailServices;
using KormosalaWebApi.Infrastructure.Services.Token;
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
            services.AddScoped<ITokenHandler, TokenHandler>();

            services.AddScoped<IMailService,MailService>();
            services.AddScoped<IApplicationService, ApplicationService>();
        }
    }
}

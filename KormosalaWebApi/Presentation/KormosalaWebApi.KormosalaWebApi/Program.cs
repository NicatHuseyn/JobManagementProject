
using FluentValidation.AspNetCore;
using KormosalaWebApi.Application;
using KormosalaWebApi.Application.Featuers.Commands.IndustryCommands.CreateIndustry;
using KormosalaWebApi.Infrastructure;
using KormosalaWebApi.KormosalaWebApi.Configurations.ColumnWriters;
using KormosalaWebApi.KormosalaWebApi.Extensions;
using KormosalaWebApi.KormosalaWebApi.Middlewares;
using KormosalaWebApi.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace KormosalaWebApi.KormosalaWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Services
            #region Custom Services
            builder.Services.AddPersistenceService();
            builder.Services.AddApplicationService();
            builder.Services.AddInfrastructureService();
            #endregion


            #region Add Cors
            builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("http://localhost:5174", "http://localhost:5174", "http://localhost:5173", "http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
            }));
            #endregion

            #region Serilog

            SqlColumn sqlColumn = new SqlColumn();
            sqlColumn.ColumnName = "UserName";
            sqlColumn.DataType = System.Data.SqlDbType.NVarChar;
            sqlColumn.PropertyName = "UserName";
            sqlColumn.DataLength = 50;
            sqlColumn.AllowNull = true;

            ColumnOptions columnOptions = new ColumnOptions();


            Logger log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt")
                .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("SqlServer"), sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions
                {
                    AutoCreateSqlTable = true,
                    TableName = "logs"
                },
                appConfiguration: null,
                columnOptions: columnOptions
                )
                .WriteTo.Seq(builder.Configuration["Seq:ServerUrl"])
                .Enrich.FromLogContext()
                .Enrich.With<CustomUserNameColumn>()
                .MinimumLevel.Information()
                .CreateLogger();

            builder.Host.UseSerilog(log);

            builder.Services.AddHttpLogging(logging =>
            {
                logging.LoggingFields = HttpLoggingFields.All;
                logging.ResponseHeaders.Add("sec-ch-ua");
                logging.MediaTypeOptions.AddText("application/javascript");
                logging.RequestBodyLogLimit = 4096;
                logging.ResponseBodyLogLimit = 4096;
            });

            #endregion


            // Add services to the container.

            #region Fluent validation
            builder.Services.AddControllers().AddFluentValidation(fv =>
            {
                fv.ImplicitlyValidateChildProperties = true;
                fv.ImplicitlyValidateRootCollectionElements = true;
                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                fv.RegisterValidatorsFromAssemblyContaining<CreateIndustryCommandRequest>();
            });
            #endregion
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region JWT Configuration
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer("Admin", options =>
                 {
                     options.TokenValidationParameters = new()
                     {
                         ValidateAudience = true,
                         ValidateIssuer = true,
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,

                         ValidAudience = builder.Configuration["Token:Auidence"],
                         ValidIssuer = builder.Configuration["Token:Issure"],
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
                         LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires is not null ? expires > DateTime.UtcNow : false,
                         NameClaimType = ClaimTypes.Name
                     };
                 });
            #endregion



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseStaticFiles();

            app.UseSerilogRequestLogging();
            app.UseHttpLogging();

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            #region Serilog Middleware Configuration
            app.Use(async (context, next) =>
            {
                var userName = context.User.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;

                LogContext.PushProperty("UserName", userName);

                await next();
            });
            #endregion


            app.MapControllers();

            app.Run();
        }
    }
}


using FluentValidation.AspNetCore;
using KormosalaWebApi.Application;
using KormosalaWebApi.Application.Featuers.Commands.IndustryCommands.CreateIndustry;
using KormosalaWebApi.Infrastructure;
using KormosalaWebApi.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
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

            // Add services to the container.

            builder.Services.AddControllers().AddFluentValidation(fv =>
            {
                fv.ImplicitlyValidateChildProperties = true;
                fv.ImplicitlyValidateRootCollectionElements = true;
                fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                fv.RegisterValidatorsFromAssemblyContaining<CreateIndustryCommandRequest>();
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
                     };
                 });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseStaticFiles();

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

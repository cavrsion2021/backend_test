using Anagrama.Api.Application.Common.Interfaces;
using Anagrama.Api.Infrastructure.Persistence;
using Anagrama.Api.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Anagrama.Api.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
                configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 26)),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IAnagram, AnagramService>();


            return services;
        }
    }
}
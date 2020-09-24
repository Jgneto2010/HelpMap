using HelpMap.CrossCutting.Identity.Models;
using HelpMap.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HelpMap.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), x => x.UseNetTopologySuite()));

            services.AddDbContext<ContextEntity>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        }
    }
}
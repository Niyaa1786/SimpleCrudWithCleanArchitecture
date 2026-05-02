using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleCrud.Application.Interfaces;
using SimpleCrud.Infrastructure.Data;
using SimpleCrud.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Infrastructure
{
    public static class AddInfrastructureDI
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork,UnitOfWork>();
            return services;
        }
    }
}

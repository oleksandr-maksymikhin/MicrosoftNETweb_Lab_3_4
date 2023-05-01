using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovieTicket.DAL.EF;
using MovieTicket.DAL.Infrastructure;
using MovieTicket.DAL.Interfaces;
using MovieTicket.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.BLL.Infrastructure
{
    public static class BllDependencyProvider
    {
        public static IServiceCollection SetBllDependencies(this IServiceCollection services, string connectionString)
        {
            //services.AddSingleton<MovieContext>();
            //services.AddDbContext<MovieContext>();
            services.SetDalDependencies(connectionString);
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            return services;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieTicket.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.DAL.Infrastructure
{
    public static class DalDependencyProvider
    {
        public static IServiceCollection SetDalDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MovieContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            return services;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Sample.IoC.Persistence.Repositories;
using Sample.IoC.Domain.Interfaces;
using Sample.IoC.Domain.Repositories;
using Sample.IoC.Services;

namespace Sample.IoC.Dependency
{
    public static class ServicesDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddTransient<IServiceClub, ServiceClub>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

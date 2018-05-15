using System;
using Microsoft.Extensions.DependencyInjection;
using Names.API.Clients;
using Names.Infrastructure.Client;
using Names.Infrastructure.Repositories;

namespace Names.API
{
    public static class DependencyInjection
    {
        public static void AddProjectDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDbClient, DatabaseClient>();
            services.AddScoped<NameRepository>();
            services.AddScoped<YearRepository>();
            services.AddScoped<QuantityRepository>();
        }
    }
}

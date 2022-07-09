#region

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Contexts;

#endregion

namespace Api.Dependencies
{
    public static class SqlServer
    {
        public static IServiceCollection RegisterSqlServer(this IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION_STRING") ??
                                   throw new InvalidOperationException("SQLSERVER_CONNECTION_STRING is not defined");

            services.AddDbContext<BlogContext>(options =>
                options.UseSqlServer(connectionString, providerOptions => providerOptions.EnableRetryOnFailure()));

            return services;
        }

        public static void EnsureMigrationOfContext<T>(this IServiceScope serviceScope) where T : DbContext
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<T>();

            context.Database.Migrate();
        }
    }
}
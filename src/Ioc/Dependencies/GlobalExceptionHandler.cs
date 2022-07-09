#region

using Ioc.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Ioc.Dependencies
{
    public static class GlobalExceptionHandler
    {
        public static IServiceCollection RegisterGlobalExceptionHandler(this IServiceCollection services)
        {
            return services.AddScoped<GlobalExceptionMiddleware>();
        }

        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
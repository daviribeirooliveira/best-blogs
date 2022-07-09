#region

using Ioc.Dependencies;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Interfaces;
using Service;
using Service.Interfaces;

#endregion

namespace Ioc
{
    public static class DependencyContainer
    {
        public static void RegisterIoc(this IServiceCollection services)
        {
            // Infrastructure
            services
                .RegisterAutoMapper()
                .RegisterSqlServer();

            // Repositories
            services
                .AddScoped<IPostRepository, PostRepository>()
                .AddScoped<ICommentRepository, CommentRepository>();

            // Service
            services
                .AddScoped<IPostService, PostService>()
                .AddScoped<ICommentService, CommentService>();
        }
    }
}
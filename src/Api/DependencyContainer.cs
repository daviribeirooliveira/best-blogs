#region

using Api.Dependencies;
using Api.Services;
using Api.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Interfaces;

#endregion

namespace Api
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
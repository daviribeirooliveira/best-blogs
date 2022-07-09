#region

using AutoMapper;
using Ioc.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Ioc.Dependencies
{
    public static class AutoMapper
    {
        public static MapperConfiguration MapperConfigurationBuilder()
        {
            return new MapperConfiguration(mapperConfigurationExpression =>
                mapperConfigurationExpression
                    .AddProfiles(new Profile[]
                    {
                        new EntitiesProfiles(),
                        new DtosProfiles()
                    })
            );
        }

        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(MapperConfigurationBuilder().CreateMapper());

            return services;
        }
    }
}
#region

using Api.MapperProfiles;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Api.Dependencies
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
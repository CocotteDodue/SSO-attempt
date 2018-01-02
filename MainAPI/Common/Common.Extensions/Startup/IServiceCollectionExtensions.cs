using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Common.Extensions.Startup
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services, Assembly profileAssembly)
        {
            var profiles = profileAssembly.GetTypes()
                               .Where(x => typeof(Profile).IsAssignableFrom(x));

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
            
            IMapper mapper = config.CreateMapper();
            services.AddScoped(x => mapper);

            return services;
        }
    }
}

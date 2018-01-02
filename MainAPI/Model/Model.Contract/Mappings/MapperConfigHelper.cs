using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace ModelContract.Mappings
{
    public class MapperConfigHelper
    {
        public IMapper RegisterProfilesFromAssembly(Assembly profileAssembly)
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

            return config.CreateMapper();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;

namespace Common.DeveloperTools.DataInitialization
{
    public static class AppilcationBuilderExtensions
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app, IConfiguration configuration)
        {
            var context = new MainApiDbContext(new DbContextOptionsBuilder<MainApiDbContext>()
                                                    .UseSqlServer(configuration.GetConnectionString("MasterDb"))
                                                    .Options);
            context.Initialise();

            return app;
        }
    }


}

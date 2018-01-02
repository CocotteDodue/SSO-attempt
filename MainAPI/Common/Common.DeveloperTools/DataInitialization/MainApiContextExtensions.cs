using Microsoft.EntityFrameworkCore;
using Model;

namespace Common.DeveloperTools.DataInitialization
{
    public static class MainApiContextExtensions
    {
        public static void Initialise(this MainApiDbContext context)
        {
            context.Database.Migrate();
            context.SeedData();
        }

        public static void SeedData(this MainApiDbContext context)
        {
            // Do seeding here
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Model
{
    public class MainApiDbContextFactory : IDesignTimeDbContextFactory<MainApiDbContext>
    {
        public MainApiDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MainApiDbContext>();
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=mainapi;Trusted_Connection=True;");

            return new MainApiDbContext(optionsBuilder.Options);
        }
    }
}

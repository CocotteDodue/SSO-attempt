using ModelContract.Entities;
using ModelContract.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace Model
{
    public partial class MainApiDbContext : DbContext, IMainApiDbContext
    {
        public virtual DbSet<Cv> Cv { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserCv> UserCv { get; set; }

        public MainApiDbContext(DbContextOptions<MainApiDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityMethod = typeof(ModelBuilder).GetMethods().FirstOrDefault(x => x.Name == "Entity" && x.IsGenericMethodDefinition);

            var entities = typeof(EntityBase).Assembly
                .GetTypes()
                .Where(x => x.GetTypeInfo().BaseType == typeof(EntityBase));

            foreach (var entity in entities)
            {
                var constructedMethod = entityMethod.MakeGenericMethod(entity);

                constructedMethod.Invoke(modelBuilder, null);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}

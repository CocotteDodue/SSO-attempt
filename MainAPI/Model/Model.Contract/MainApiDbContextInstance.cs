using ModelContract.Interfaces;

namespace ModelContract
{
    public class MainApiDbContextInstance
    {
        public string ConnectionString { get; set; }
        public IMainApiDbContext ExistingDbContext { get; set; }
        public MainApiDbContextInstance(string connectionString, IMainApiDbContext existingDbContext = null)
        {
            ConnectionString = connectionString;
            ExistingDbContext = existingDbContext;
        }
    }
}

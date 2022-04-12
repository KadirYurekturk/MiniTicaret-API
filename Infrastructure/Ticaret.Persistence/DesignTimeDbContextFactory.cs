using Microsoft.EntityFrameworkCore.Design;

namespace Ticaret.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TicaretDbContext>
    {
        public TicaretDbContext CreateDbContext(string[] args)
        {
            

            DbContextOptionsBuilder<TicaretDbContext> optionsBuilder = new();
            optionsBuilder.UseNpgsql(SqlConfiguration.ConnectionString);

            return new(optionsBuilder.Options);
        }
    }
}

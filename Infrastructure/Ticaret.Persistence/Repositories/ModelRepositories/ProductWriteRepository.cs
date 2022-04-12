namespace Ticaret.Persistence.Repositories.ModelRepositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(TicaretDbContext dbContext) : base(dbContext)
        {
        }
    }
}

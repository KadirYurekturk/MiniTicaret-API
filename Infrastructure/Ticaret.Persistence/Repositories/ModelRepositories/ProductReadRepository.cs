namespace Ticaret.Persistence.Repositories.ModelRepositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(TicaretDbContext context) : base(context)
        {
        }
    }
}

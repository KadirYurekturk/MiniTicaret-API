namespace Ticaret.Persistence.Repositories.ModelRepositories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(TicaretDbContext dbContext) : base(dbContext)
        {
        }
    }
}

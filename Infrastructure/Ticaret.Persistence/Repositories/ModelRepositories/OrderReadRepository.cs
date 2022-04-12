namespace Ticaret.Persistence.Repositories.ModelRepositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(TicaretDbContext context) : base(context)
        {
        }      
    }
}

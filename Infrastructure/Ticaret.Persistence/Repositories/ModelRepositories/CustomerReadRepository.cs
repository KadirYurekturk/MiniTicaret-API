namespace Ticaret.Persistence.Repositories.ModelRepositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(TicaretDbContext context) : base(context)
        {
        }

    }
}

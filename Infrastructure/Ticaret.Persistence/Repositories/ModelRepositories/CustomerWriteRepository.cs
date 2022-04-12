namespace Ticaret.Persistence.Repositories.ModelRepositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(TicaretDbContext dbContext) : base(dbContext)
        {
        }
    }
}

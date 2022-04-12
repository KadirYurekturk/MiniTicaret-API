namespace Ticaret.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly TicaretDbContext _context;

        public ReadRepository(TicaretDbContext context)
            => _context = context;


        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool trackChanges = true)
        {
            var query = Table.AsQueryable();
            if (!trackChanges)
                query = query.AsNoTracking();
            return query;
        }


        public async Task<T> GetByIdAsync(string id, bool trackChanges = true)
        {
            var query = Table.AsQueryable();
            if (!trackChanges)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expresion, bool trackChanges = true)
        {
            var query = Table.AsQueryable();
            if (!trackChanges)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(expresion);
            //   await Table.FindAsync(expresion);
        }


        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expresion, bool trackChanges = true)
        {
            var query = Table.AsQueryable();
            if (!trackChanges)
                query = query.AsNoTracking();
            return query.Where(expresion);
            //Table.Where(expresion);
        }

    }
}

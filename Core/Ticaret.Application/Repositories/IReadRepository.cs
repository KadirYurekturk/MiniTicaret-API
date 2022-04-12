namespace Ticaret.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T: BaseEntity
    {
        IQueryable<T> GetAll(bool trackChanges = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expresion, bool trackChanges = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> expresion, bool trackChanges = true);
        Task<T> GetByIdAsync(string id, bool trackChanges = true);
        
    }
}

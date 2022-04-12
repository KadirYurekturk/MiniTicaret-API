using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Domain.Entities.Common;

namespace Ticaret.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);        
        bool Update(T entity);
        bool Delete(T entity);
        bool DeleteRange(List<T> entities);
        Task<bool> Delete(string id);
        Task<int> SaveAsync();
    }
}

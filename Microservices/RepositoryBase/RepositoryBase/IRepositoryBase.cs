using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryBase
{
    public interface IRepositoryBase<T>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        Task<IEnumerable<T>> CreateMany(IEnumerable<T> entities);
        Task<bool> Update(T entity);
        Task<bool> UpdateMany(IEnumerable<T> entities);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteMany(IEnumerable<Guid> id);
        Task<bool> Restore(Guid id);
        Task<bool> RestoreMany(IEnumerable<Guid> id);
    }
}

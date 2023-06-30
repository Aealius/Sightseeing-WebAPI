
using System.Linq.Expressions;

namespace DAL.Repository_Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        Task <IEnumerable<TEntity>> GetAllAsync();
        Task <TEntity> GetByIdAsync(uint id);
        Task AddAsync(TEntity item);
        Task UpdateAsync(uint id, TEntity item);
        Task DeleteAsync(uint id);
    }
}

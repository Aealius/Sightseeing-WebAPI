using DAL.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity:class
    {
        protected readonly SightseeingdbContext _context;

        public BaseRepository(SightseeingdbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity item)
        {
            await _context.AddAsync(item);
        }

        public async Task DeleteAsync(uint id)
        {
            var entityToDelete = await _context.FindAsync<TEntity>(id);
            _context.Remove(entityToDelete);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(uint id)
        {
            return await _context.FindAsync<TEntity>(id);
        }

        public async Task UpdateAsync(uint id, TEntity item)
        {
            var entityToUpdate = await _context.FindAsync<TEntity>(id);
            _context.Entry<TEntity>(entityToUpdate).CurrentValues.SetValues(item);
        }
    }
}

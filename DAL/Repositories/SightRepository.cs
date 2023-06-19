using DAL.Entities;
using DAL.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SightRepository: BaseRepository<Sight>, ISightRepository
    {
        public SightRepository(SightseeingdbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Sight>> GetAdditionalInfoAllAsync()
        {
            var items = await _context.Set<Sight>()
                                      .Include(s => s.Reviews)
                                      .Include(s => s.TourSights)
                                      .ThenInclude(t => t.Tour)
                                      .AsNoTracking()
                                      .ToListAsync();

            return items;
        }

        public async Task<Sight> GetAdditionalInfoByIdAsync(int id)
        {
            var item = await _context.Set<Sight>()
                                     .Include(s => s.Reviews)
                                     .Include(s => s.TourSights)
                                     .ThenInclude(t => t.Tour)
                                     .FirstOrDefaultAsync(s => s.SightId == id);
                                        
            return item;
        }
    }
}

using DAL.Entities;
using DAL.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TourRepository : BaseRepository<Tour>, ITourRepository
    {
        public TourRepository(SightseeingdbContext context) : base(context)
        {

            
        }

        public async Task<IEnumerable<Tour>> GetAdditionalInfoAllAsync()
        {
            var items = await _context.Set<Tour>()
                                      .Include(t => t.GuideTours)
                                      .ThenInclude(g => g.Guide)
                                      .Include(t => t.TourSights)
                                      .AsNoTracking()
                                      .ToListAsync();
            return items;
        }

        public async Task<Tour> GetAdditionalInfoByIdAsync(int id)
        {
            var item = await _context.Set<Tour>()
                                     .Include(t => t.GuideTours)
                                     .ThenInclude(g => g.Guide)
                                     .Include(t => t.TourSights)
                                     .FirstOrDefaultAsync(t => t.TourId == id);

            return item;
        }
    }
}

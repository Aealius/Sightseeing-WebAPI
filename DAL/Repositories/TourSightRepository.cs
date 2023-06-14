using DAL.Entities;
using DAL.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TourSightRepository : BaseRepository<TourSight>, ITourSightRepository
    {
        public TourSightRepository(SightseeingdbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<TourSight>> GetAdditionalInfoAllAsync()
        {
            var items = await _context.Set<TourSight>()
                                      .Include(ts => ts.Tour)
                                      .Include(ts => ts.Sight)
                                      .AsNoTracking()
                                      .ToListAsync();

            return items;
        }

        public async Task<TourSight> GetAdditionalInfoByIdAsync(int idTour, int idSight)
        {
            var item = await _context.Set<TourSight>()
                                     .Include(ts => ts.Tour)
                                     .Include(ts => ts.Sight)
                                     .FirstOrDefaultAsync(ts => ts.TourId == idTour && ts.SightId == idSight);

            return item;
        }
    }
}

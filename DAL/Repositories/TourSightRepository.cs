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
                                     .FirstOrDefaultAsync(ts => ts.TourId.Equals(idTour) && ts.SightId.Equals(idSight));

            return item;
        }

        public async Task DeleteAsync(int idTour, int idSight)//for m:m tables
        {
            var item = await _context.Set<TourSight>()
                                     .FirstOrDefaultAsync(ts => ts.TourId.Equals(idTour) && ts.SightId.Equals(idSight));

            _context.Set<TourSight>().Remove(item);
        }
    }
}

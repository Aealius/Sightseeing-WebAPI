using DAL.Entities;
using DAL.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class GuideTourRepository : BaseRepository<GuideTour>, IGuideTourRepository
    {
        public GuideTourRepository(SightseeingdbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<GuideTour>> GetAdditionalInfoAllAsync()
        {
            var items = await _context.Set<GuideTour>()
                                     .Include(gt => gt.Tour)
                                     .Include(gt => gt.Guide)
                                     .AsNoTracking()
                                     .ToListAsync();

            return items;
        }

        public async Task<GuideTour> GetAdditionalInfoByIdAsync(int idGuide, int idTour)
        {
            var item = await _context.Set<GuideTour>()
                                     .Include(gt => gt.Tour)
                                     .Include(gt => gt.Guide)
                                     .FirstOrDefaultAsync(gt => gt.GuideId == idGuide && gt.TourId == idTour);

            return item;
        }
    }
}

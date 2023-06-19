using DAL.Entities;
using DAL.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ReviewRepository:BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(SightseeingdbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Review>> GetAdditionalInfoAllAsync()
        {
            var items = await _context.Set<Review>()
                                      .Include(r => r.User)
                                      .Include(r => r.Sight)
                                      .AsNoTracking()
                                      .ToListAsync();

            return items;                      
        }

        public async Task<Review> GetAdditionalInfoByIdAsync(int id)
        {
            var item = await _context.Set<Review>()
                                     .Include(r => r.User)
                                     .Include(r => r.Sight)
                                     .FirstOrDefaultAsync(r => r.ReviewId == id);

            return item;
        }
    }
}

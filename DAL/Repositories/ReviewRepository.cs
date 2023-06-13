using DAL.Entities;
using DAL.Repository_Interfaces;

namespace DAL.Repositories
{
    public class ReviewRepository:BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(SightseeingdbContext context) : base(context)
        {
            
        }
    }
}

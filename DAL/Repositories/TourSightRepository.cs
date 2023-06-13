using DAL.Entities;
using DAL.Repository_Interfaces;

namespace DAL.Repositories
{
    public class TourSightRepository : BaseRepository<TourSight>, ITourSightRepository
    {
        public TourSightRepository(SightseeingdbContext context) : base(context)
        {
            
        }
    }
}

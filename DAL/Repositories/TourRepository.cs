using DAL.Entities;
using DAL.Repository_Interfaces;

namespace DAL.Repositories
{
    public class TourRepository : BaseRepository<Tour>, ITourRepository
    {
        public TourRepository(SightseeingdbContext context) : base(context)
        {
            
        }
    }
}

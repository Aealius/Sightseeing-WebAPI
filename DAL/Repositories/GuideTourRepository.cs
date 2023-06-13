using DAL.Entities;
using DAL.Repository_Interfaces;

namespace DAL.Repositories
{
    public class GuideTourRepository : BaseRepository<GuideTour>, IGuideTourRepository
    {
        public GuideTourRepository(SightseeingdbContext context) : base(context)
        {
            
        }
    }
}

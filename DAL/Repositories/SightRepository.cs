using DAL.Entities;
using DAL.Repository_Interfaces;

namespace DAL.Repositories
{
    public class SightRepository: BaseRepository<Sight>, ISightRepository
    {
        public SightRepository(SightseeingdbContext context) : base(context)
        {
            
        }
    }
}

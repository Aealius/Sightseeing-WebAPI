using DAL.Entities;
using DAL.Repository_Interfaces;

namespace DAL.Repositories
{
    public class GuideRepository : BaseRepository<Guide>, IGuideRepository 
    {
        public GuideRepository(SightseeingdbContext context) : base(context)
        {
            
        }
    }
}

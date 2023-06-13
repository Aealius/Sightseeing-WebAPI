using DAL.Entities;
using DAL.Repository_Interfaces;

namespace DAL.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(SightseeingdbContext context) : base(context)
        {
            
        }
    }
}

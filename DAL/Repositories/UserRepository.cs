using DAL.Entities;
using DAL.Repository_Interfaces;

namespace DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SightseeingdbContext context) : base(context)
        {
            
        }
    }
}

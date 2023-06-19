using DAL.Entities;
using DAL.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SightseeingdbContext context) : base(context)
        {
            
        }

        //gets list of users and their additional info
        public async Task<IEnumerable<User>> GetAdditionalInfoAllAsync()
        {
            var items = await _context.Set<User>()
                               .Include(user => user.Role)
                               .Include(user => user.Reviews)
                               .Include(user => user.Tickets)
                               .AsNoTracking()
                               .ToListAsync();

            return items;
        }

        //gets one specified by id user object with add. info
        public async Task<User> GetAdditionalInfoByIdAsync(int id)
        {
            var item = await _context.Set<User>()
                                 .Include(user => user.Role)
                                 .Include(user => user.Reviews)
                                 .Include(user => user.Tickets)
                                 .FirstOrDefaultAsync(user => user.UserId == id);
            
            return item;
        }
    }
}

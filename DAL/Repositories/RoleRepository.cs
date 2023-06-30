using DAL.Entities;
using DAL.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(SightseeingdbContext context) : base(context)
        {
 
        }

        public async Task<IEnumerable<Role>> GetAdditionalInfoAllAsync()
        {
            var items = await _context.Set<Role>()
                                      .Include(r => r.Users)
                                      .AsNoTracking()
                                      .ToListAsync();

            return items;                           
        }

        public async Task<Role> GetAdditionalInfoByIdAsync(uint id)
        {
            var item = await _context.Set<Role>()
                                     .Include(r => r.Users)
                                     .FirstOrDefaultAsync(r=> r.RoleId == id);

            return item;
        }
    }
}

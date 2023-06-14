using DAL.Entities;
using DAL.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TicketRepository:BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(SightseeingdbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Ticket>> GetAdditionalInfoAllAsync()
        {
            var items = await _context.Set<Ticket>()
                                      .Include(ticket => ticket.Tour)
                                      .Include(ticket => ticket.User)
                                      .AsNoTracking()
                                      .ToListAsync();

            return items;
        }

        public async Task<Ticket> GetAdditionalInfoByIdAsync(int id)
        {
            var item = await _context.Set<Ticket>()
                                     .Include(ticket => ticket.Tour)
                                     .Include(ticket => ticket.User)
                                     .FirstOrDefaultAsync(ticket => ticket.TicketId == id);

            return item;
        }
    }
}

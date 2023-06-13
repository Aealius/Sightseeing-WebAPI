using DAL.Entities;
using DAL.Repository_Interfaces;

namespace DAL.Repositories
{
    public class TicketRepository:BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(SightseeingdbContext context) : base(context)
        {
            
        }
    }
}

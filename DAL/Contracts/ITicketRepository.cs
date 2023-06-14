using DAL.Entities;

namespace DAL.Repository_Interfaces
{
    public interface ITicketRepository:IBaseRepository<Ticket>
    {
        Task<Ticket> GetAdditionalInfoByIdAsync(int id);
        Task<IEnumerable<Ticket>> GetAdditionalInfoAllAsync();
    }
}

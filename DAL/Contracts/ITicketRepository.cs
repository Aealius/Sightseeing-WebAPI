using DAL.Entities;

namespace DAL.Repository_Interfaces
{
    public interface ITicketRepository:IBaseRepository<Ticket>
    {
        Task<Ticket> GetAdditionalInfoByIdAsync(uint id);
        Task<IEnumerable<Ticket>> GetAdditionalInfoAllAsync();
    }
}

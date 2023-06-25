using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface ITicketService
    {
        Task AddAsync(TicketDTOModel addTicketDTO);
        Task DeleteAsync(int id);
        Task<List<TicketDTOModel>> GetAllAsync();
        Task<TicketDTOModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, TicketDTOModel updateTicketDTO);
    }
}

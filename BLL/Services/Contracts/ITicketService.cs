using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface ITicketService
    {
        Task AddAsync(TicketDTOModel addTicketDTO);
        Task DeleteAsync(uint id);
        Task<List<TicketDTOModel>> GetAllAsync();
        Task<TicketDTOModel> GetByIdAsync(uint id);
        Task UpdateAsync(uint id, TicketDTOModel updateTicketDTO);
    }
}

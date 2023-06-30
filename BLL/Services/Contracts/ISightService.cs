using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface ISightService
    {
        Task AddAsync(SightDTOModel addSightDTO);
        Task DeleteAsync(uint id);
        Task<List<SightDTOModel>> GetAllAsync();
        Task<SightDTOModel> GetByIdAsync(uint id);
        Task UpdateAsync(uint id, SightDTOModel updateSightDTO);
    }
}

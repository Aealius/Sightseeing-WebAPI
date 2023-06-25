using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface ISightService
    {
        Task AddAsync(SightDTOModel addSightDTO);
        Task DeleteAsync(int id);
        Task<List<SightDTOModel>> GetAllAsync();
        Task<SightDTOModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, SightDTOModel updateSightDTO);
    }
}

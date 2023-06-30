using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface ITourService
    {
        Task AddAsync(TourDTOModel addTourDTO);
        Task DeleteAsync(uint id);
        Task<List<TourDTOModel>> GetAllAsync();
        Task<TourDTOModel> GetByIdAsync(uint id);
        Task UpdateAsync(uint id, TourDTOModel updateTourDTO);
    }
}

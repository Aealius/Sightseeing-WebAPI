using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface ITourService
    {
        Task AddAsync(TourDTOModel addTourDTO);
        Task DeleteAsync(int id);
        Task<List<TourDTOModel>> GetAllAsync();
        Task<TourDTOModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, TourDTOModel updateTourDTO);
    }
}

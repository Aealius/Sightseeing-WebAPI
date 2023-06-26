using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface ITourSightService
    {
        Task AddAsync(TourSightDTOModel addTourSightDTO);
        Task DeleteAsync(int idTour, int idSight);
        Task<List<TourSightDTOModel>> GetAllAsync();
    }
}

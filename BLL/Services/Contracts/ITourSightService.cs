using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface ITourSightService
    {
        Task AddAsync(TourSightDTOModel addTourSightDTO);
        Task DeleteAsync(uint idTour, uint idSight);
        Task<List<TourSightDTOModel>> GetAllAsync();
    }
}

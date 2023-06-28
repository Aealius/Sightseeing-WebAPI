using DAL.Entities;

namespace DAL.Repository_Interfaces
{
    public interface ITourSightRepository:IBaseRepository<TourSight>
    {
        Task<TourSight> GetAdditionalInfoByIdAsync(uint idTour, uint idSight);
        Task<IEnumerable<TourSight>> GetAdditionalInfoAllAsync();
        Task DeleteAsync(uint idTour, uint idSight);
    }
}

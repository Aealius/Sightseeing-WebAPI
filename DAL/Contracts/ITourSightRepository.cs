using DAL.Entities;

namespace DAL.Repository_Interfaces
{
    public interface ITourSightRepository:IBaseRepository<TourSight>
    {
        Task<TourSight> GetAdditionalInfoByIdAsync(int idTour, int idSight);
        Task<IEnumerable<TourSight>> GetAdditionalInfoAllAsync();
    }
}

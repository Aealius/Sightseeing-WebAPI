using DAL.Entities;

namespace DAL.Repository_Interfaces
{
    public interface IGuideTourRepository:IBaseRepository<GuideTour>
    {
        Task<GuideTour> GetAdditionalInfoByIdAsync(int idGuide, int idTour);
        Task<IEnumerable<GuideTour>> GetAdditionalInfoAllAsync();
        Task DeleteAsync(int idGuide, int idTour);
    }
}

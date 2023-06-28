using DAL.Entities;

namespace DAL.Repository_Interfaces
{
    public interface IGuideTourRepository:IBaseRepository<GuideTour>
    {
        Task<GuideTour> GetAdditionalInfoByIdAsync(uint idGuide, uint idTour);
        Task<IEnumerable<GuideTour>> GetAdditionalInfoAllAsync();
        Task DeleteAsync(uint idGuide, uint idTour);
    }
}

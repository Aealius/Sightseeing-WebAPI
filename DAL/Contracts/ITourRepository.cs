using DAL.Entities;

namespace DAL.Repository_Interfaces
{
    public interface ITourRepository:IBaseRepository<Tour>
    {
        Task<Tour> GetAdditionalInfoByIdAsync(uint id);
        Task<IEnumerable<Tour>> GetAdditionalInfoAllAsync();
    }
}

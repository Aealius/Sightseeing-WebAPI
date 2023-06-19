using DAL.Entities;

namespace DAL.Repository_Interfaces
{
    public interface ITourRepository:IBaseRepository<Tour>
    {
        Task<Tour> GetAdditionalInfoByIdAsync(int id);
        Task<IEnumerable<Tour>> GetAdditionalInfoAllAsync();
    }
}

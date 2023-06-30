using DAL.Entities;

namespace DAL.Repository_Interfaces
{
    public interface ISightRepository:IBaseRepository<Sight>
    {
        Task<Sight> GetAdditionalInfoByIdAsync(uint id);
        Task<IEnumerable<Sight>> GetAdditionalInfoAllAsync();
    }
}

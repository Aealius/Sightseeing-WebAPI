using DAL.Entities;

namespace DAL.Repository_Interfaces
{
    public interface IRoleRepository:IBaseRepository<Role>
    {
        Task<Role> GetAdditionalInfoByIdAsync(uint id);
        Task<IEnumerable<Role>> GetAdditionalInfoAllAsync();
    }
}

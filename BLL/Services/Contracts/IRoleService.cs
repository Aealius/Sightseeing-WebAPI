using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface IRoleService
    {
        Task AddAsync(RoleDTOModel addRoleDTO);
        Task DeleteAsync(uint id);
        Task<List<RoleDTOModel>> GetAllAsync();
        Task<RoleDTOModel> GetByIdAsync(uint id);
        Task UpdateAsync(uint id, RoleDTOModel updateRoleDTO);
    }
}

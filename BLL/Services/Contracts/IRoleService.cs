using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface IRoleService
    {
        Task AddAsync(RoleDTOModel addRoleDTO);
        Task DeleteAsync(int id);
        Task<List<RoleDTOModel>> GetAllAsync();
        Task<RoleDTOModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, RoleDTOModel updateRoleDTO);
    }
}

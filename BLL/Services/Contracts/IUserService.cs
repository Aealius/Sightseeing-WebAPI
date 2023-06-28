using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface IUserService
    {
        Task AddAsync(UserDTOModel addUserDTO);
        Task DeleteAsync(uint id);
        Task<List<UserDTOModel>> GetAllAsync();
        Task<UserDTOModel> GetByIdAsync(uint id);
        Task UpdateAsync(uint id, UserDTOModel updateUserDTO);
    }
}

using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface IUserService
    {
        Task AddAsync(UserDTOModel addUserDTO);
        Task DeleteAsync(int id);
        Task<List<UserDTOModel>> GetAllAsync();
        Task<UserDTOModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, UserDTOModel updateUserDTO);
    }
}

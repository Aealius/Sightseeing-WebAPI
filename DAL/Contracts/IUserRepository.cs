using DAL.Entities;

namespace DAL.Repository_Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> GetAdditionalInfoAllAsync();
        Task<User> GetAdditionalInfoByIdAsync(int id);
    }
}

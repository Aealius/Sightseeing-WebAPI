using DAL.Entities;

namespace DAL.Repository_Interfaces
{
    public interface IReviewRepository:IBaseRepository<Review>
    {
        Task<Review> GetAdditionalInfoByIdAsync(uint id);
        Task<IEnumerable<Review>> GetAdditionalInfoAllAsync();
    }
}

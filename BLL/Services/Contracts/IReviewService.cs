using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface IReviewService
    {
        Task AddAsync(ReviewDTOModel addReviewDTO);
        Task DeleteAsync(int id);
        Task<List<ReviewDTOModel>> GetAllAsync();
        Task<ReviewDTOModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, ReviewDTOModel updateReviewDTO);
    }
}

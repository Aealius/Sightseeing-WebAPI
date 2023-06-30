using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface IReviewService
    {
        Task AddAsync(ReviewDTOModel addReviewDTO);
        Task DeleteAsync(uint id);
        Task<List<ReviewDTOModel>> GetAllAsync();
        Task<ReviewDTOModel> GetByIdAsync(uint id);
        Task UpdateAsync(uint id, ReviewDTOModel updateReviewDTO);
    }
}

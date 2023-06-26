using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface IGuideService
    {
        Task AddAsync(GuideDTOModel guideDTO);
        Task DeleteAsync(int id);
        Task<List<GuideDTOModel>> GetAllAsync();
        Task<GuideDTOModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, GuideDTOModel updateGuideDTO);
    }
}

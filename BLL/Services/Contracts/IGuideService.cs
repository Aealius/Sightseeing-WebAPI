using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface IGuideService
    {
        Task AddAsync(GuideDTOModel guideDTO);
        Task DeleteAsync(uint id);
        Task<List<GuideDTOModel>> GetAllAsync();
        Task<GuideDTOModel> GetByIdAsync(uint id);
        Task UpdateAsync(uint id, GuideDTOModel updateGuideDTO);
    }
}

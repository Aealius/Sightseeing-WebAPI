using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface IGuideTourService
    {
        Task AddAsync(GuideTourDTOModel addGuideTourDTO);
        Task DeleteAsync(uint guideId, uint tourId);
        Task<List<GuideTourDTOModel>> GetAllAsync();
    }
}

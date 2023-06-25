using BLL.Models;

namespace BLL.Services.Contracts
{
    public interface IGuideTourService
    {
        Task AddAsync(GuideTourDTOModel addGuideTourDTO);
        Task DeleteAsync(int guideId, int tourId);
        Task<List<GuideTourDTOModel>> GetAllAsync();
    }
}

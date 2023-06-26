using Abp.Domain.Entities;
using AutoMapper;
using BLL.Models;
using BLL.Services.Contracts;
using DAL.Entities;
using IUnitOfWork = DAL.UnitOfWork.IUnitOfWork;

namespace BLL.Services.Implementation
{
    public class GuideService : IGuideService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GuideService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(GuideDTOModel guideDTO)
        {
            var guide = _mapper.Map<Guide>(guideDTO);
            await _unitOfWork.Guides.AddAsync(guide);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Guides.DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<GuideDTOModel>> GetAllAsync()
        {
            var guides = await _unitOfWork.Guides.GetAllAsync();
            var guidesDTOList = new List<GuideDTOModel>();

            foreach (var guide in guides)
            {
                guidesDTOList.Add(_mapper.Map<GuideDTOModel>(guide));
            }

            return guidesDTOList;
        }

        public async Task<GuideDTOModel> GetByIdAsync(int id)
        {
            var guide = await _unitOfWork.Guides.GetByIdAsync(id);

            if (guide == null)
            {
                throw new EntityNotFoundException("Guide not found");
            }

            var guideDTO = _mapper.Map<GuideDTOModel>(guide);

            return guideDTO;
        }

        public async Task UpdateAsync(int id, GuideDTOModel updateGuideDTO)
        {
            var guide = _mapper.Map<Guide>(updateGuideDTO);
            await _unitOfWork.Guides.UpdateAsync(id, guide);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

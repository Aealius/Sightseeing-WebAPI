using AutoMapper;
using BLL.Models;
using BLL.Services.Contracts;
using DAL.Entities;
using IUnitOfWork = DAL.UnitOfWork.IUnitOfWork;

namespace BLL.Services.Implementation
{
    public class GuideTourService : IGuideTourService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GuideTourService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(GuideTourDTOModel addGuideTourDTO)
        {
            var guideTour = _mapper.Map<GuideTour>(addGuideTourDTO);
            await _unitOfWork.GuideTours.AddAsync(guideTour);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int guideId, int tourId)
        {
            await _unitOfWork.GuideTours.DeleteAsync(guideId, tourId);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<GuideTourDTOModel>> GetAllAsync()
        {
            var guideTours = await _unitOfWork.GuideTours.GetAllAsync();
            var guideToursDTOList = new List<GuideTourDTOModel>();
            foreach (var guideTour in guideTours)
            {
                guideToursDTOList.Add(_mapper.Map<GuideTourDTOModel>(guideTour));
            }

            return guideToursDTOList;
        }
    }
}

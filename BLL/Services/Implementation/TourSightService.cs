using AutoMapper;
using BLL.Models;
using BLL.Services.Contracts;
using DAL.Entities;
using IUnitOfWork = DAL.UnitOfWork.IUnitOfWork;

namespace BLL.Services.Implementation
{
    public class TourSightService : ITourSightService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TourSightService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(TourSightDTOModel addTourSightDTO)
        {
            var tourSight = _mapper.Map<TourSight>(addTourSightDTO);
            await _unitOfWork.TourSights.AddAsync(tourSight);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int idTour, int idSight)
        {
            await _unitOfWork.TourSights.DeleteAsync(idTour, idSight);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<TourSightDTOModel>> GetAllAsync()
        {
            var tourSights = await _unitOfWork.TourSights.GetAllAsync();
            var tourSightsDTOList = new List<TourSightDTOModel>();
            foreach (var tourSight in tourSights)
            {
                tourSightsDTOList.Add(_mapper.Map<TourSight, TourSightDTOModel>(tourSight));
            }

            return tourSightsDTOList;
        }
    }
}

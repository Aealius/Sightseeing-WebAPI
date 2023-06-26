using Abp.Domain.Entities;
using AutoMapper;
using BLL.Models;
using BLL.Services.Contracts;
using DAL.Entities;
using IUnitOfWork = DAL.UnitOfWork.IUnitOfWork;

namespace BLL.Services.Implementation
{
    public class TourService : ITourService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TourService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(TourDTOModel addTourDTO)
        {
            var tour = _mapper.Map<Tour>(addTourDTO);
            await _unitOfWork.Tours.AddAsync(tour);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Tours.DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<TourDTOModel>> GetAllAsync()
        {
            var tours = await _unitOfWork.Tours.GetAllAsync();
            var toursDTOList = new List<TourDTOModel>();
            foreach (var tour in tours)
            {
                toursDTOList.Add(_mapper.Map<Tour, TourDTOModel>(tour));
            }

            return toursDTOList;
        }

        public async Task<TourDTOModel> GetByIdAsync(int id)
        {
            var tour = await _unitOfWork.Tours.GetByIdAsync(id);

            if (tour == null)
            {
                throw new EntityNotFoundException("Tour not found");
            }

            var tourDTO = _mapper.Map<TourDTOModel>(tour);

            return tourDTO;
        }

        public async Task UpdateAsync(int id, TourDTOModel updateTourDTO)
        {
            var tour = _mapper.Map<Tour>(updateTourDTO);
            await _unitOfWork.Tours.UpdateAsync(id, tour);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

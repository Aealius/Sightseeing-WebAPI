using Abp.Domain.Entities;
using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class TourService
    {
        private readonly IBaseRepository<Tour> _repository;
        private readonly IMapper _mapper;

        public TourService(IBaseRepository<Tour> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TourDTOModel> Add(TourDTOModel addTourDTO)
        {
            var tour = _mapper.Map<Tour>(addTourDTO);
            await _repository.AddAsync(tour);

            return _mapper.Map<TourDTOModel>(tour);
        }

        public async Task<TourDTOModel> Delete(int id)
        {
            var tour = _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(id);

            return _mapper.Map<TourDTOModel>(tour);
        }

        public async Task<List<TourDTOModel>> GetAll()
        {
            var tours = await _repository.GetAllAsync();
            var toursDTOList = new List<TourDTOModel>();
            foreach (var tour in tours)
            {
                toursDTOList.Add(_mapper.Map<Tour, TourDTOModel>(tour));
            }

            return toursDTOList;
        }

        public async Task<TourDTOModel> GetById(int id)
        {
            var tour = _repository.GetByIdAsync(id);
            if (tour == null)
            {
                throw new EntityNotFoundException("Tour not found");
            }

            return _mapper.Map<TourDTOModel>(tour);
        }

        public async Task<TourDTOModel?> Update(int id, TourDTOModel updateTourDTO)
        {
            var tour = _mapper.Map<Tour>(updateTourDTO);
            await _repository.UpdateAsync(id, tour);

            return _mapper.Map<TourDTOModel>(tour);
        }
    }
}

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
    internal class TourSightService
    {
        private readonly IBaseRepository<TourSight> _repository;
        private readonly IMapper _mapper;

        public TourSightService(IBaseRepository<TourSight> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TourSightDTOModel> Add(TourSightDTOModel addTourSightDTO)
        {
            var tourSight = _mapper.Map<TourSight>(addTourSightDTO);
            await _repository.AddAsync(tourSight);

            return _mapper.Map<TourSightDTOModel>(tourSight);
        }

        public async Task<TourSightDTOModel> Delete(int id)
        {
            var tourSight = _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(id);

            return _mapper.Map<TourSightDTOModel>(tourSight);
        }

        public async Task<List<TourSightDTOModel>> GetAll()
        {
            var tourSights = await _repository.GetAllAsync();
            var tourSightsDTOList = new List<TourSightDTOModel>();
            foreach (var tourSight in tourSights)
            {
                tourSightsDTOList.Add(_mapper.Map<TourSight, TourSightDTOModel>(tourSight));
            }

            return tourSightsDTOList;
        }

        public async Task<TourSightDTOModel> GetById(int id)
        {
            var tourSight = _repository.GetByIdAsync(id);
            if (tourSight == null)
            {
                throw new EntityNotFoundException("Sightseeing tour not found");
            }

            return _mapper.Map<TourSightDTOModel>(tourSight);
        }

        public async Task<TourSightDTOModel?> Update(int id, TourSightDTOModel updateTourSightDTO)
        {
            var tourSight = _mapper.Map<TourSight>(updateTourSightDTO);
            await _repository.UpdateAsync(id, tourSight);

            return _mapper.Map<TourSightDTOModel>(tourSight);
        }
    }
}

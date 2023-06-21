using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class TourSightService
    {
        private readonly BaseRepository<TourSight> repository;
        private readonly IMapper mapper;
        public TourSightService(BaseRepository<TourSight> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<TourSightDTOModel> Add(TourSightDTOModel addTourSightDTO)
        {
            var tourSight = mapper.Map<TourSight>(addTourSightDTO);
            await repository.AddAsync(tourSight);
            return mapper.Map<TourSightDTOModel>(tourSight);
        }
        public async Task<TourSightDTOModel> Delete(int id)
        {
            var tourSight = repository.GetByIdAsync(id);
            await repository.DeleteAsync(id);
            return mapper.Map<TourSightDTOModel>(tourSight);
        }
        public async Task<List<TourSightDTOModel>> GetAll()
        {
            var tourSights = await repository.GetAllAsync();
            var tourSightsDTOList = new List<TourSightDTOModel>();
            foreach (var tourSight in tourSights)
            {
                tourSightsDTOList.Add(mapper.Map<TourSight, TourSightDTOModel>(tourSight));
            }
            return tourSightsDTOList;
        }
        public async Task<TourSightDTOModel> GetById(int id)
        {
            var tourSight = repository.GetByIdAsync(id);
            if (tourSight == null)
                throw new ValidationException("Sightseeing tour not found");
            return mapper.Map<TourSightDTOModel>(tourSight);
        }
        public async Task<TourSightDTOModel?> Update(int id, TourSightDTOModel updateTourSightDTO)
        {
            var tourSight = mapper.Map<TourSight>(updateTourSightDTO);
            await repository.UpdateAsync(id, tourSight);
            return mapper.Map<TourSightDTOModel>(tourSight);
        }
    }
}

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
    internal class TourService
    {
        private readonly BaseRepository<Tour> repository;
        private readonly IMapper mapper;
        public TourService(BaseRepository<Tour> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<TourDTOModel> Add(TourDTOModel addTourDTO)
        {
            var tour = mapper.Map<Tour>(addTourDTO);
            await repository.AddAsync(tour);
            return mapper.Map<TourDTOModel>(tour);
        }
        public async Task<TourDTOModel> Delete(int id)
        {
            var tour = repository.GetByIdAsync(id);
            await repository.DeleteAsync(id);
            return mapper.Map<TourDTOModel>(tour);
        }
        public async Task<List<TourDTOModel>> GetAll()
        {
            var tours = await repository.GetAllAsync();
            var toursDTOList = new List<TourDTOModel>();
            foreach (var tour in tours)
            {
                toursDTOList.Add(mapper.Map<Tour, TourDTOModel>(tour));
            }
            return toursDTOList;
        }
        public async Task<TourDTOModel> GetById(int id)
        {
            var tour = repository.GetByIdAsync(id);
            if (tour == null)
                throw new ValidationException("Tour not found");
            return mapper.Map<TourDTOModel>(tour);
        }
        public async Task<TourDTOModel?> Update(int id, TourDTOModel updateTourDTO)
        {
            var tour = mapper.Map<Tour>(updateTourDTO);
            await repository.UpdateAsync(id, tour);
            return mapper.Map<TourDTOModel>(tour);
        }
    }
}

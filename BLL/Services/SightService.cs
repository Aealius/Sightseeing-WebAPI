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
    internal class SightService
    {
        private readonly BaseRepository<Sight> repository;
        private readonly IMapper mapper;
        public SightService(BaseRepository<Sight> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<SightDTOModel> Add(SightDTOModel addSightDTO)
        {
            var sight = mapper.Map<Sight>(addSightDTO);
            await repository.AddAsync(sight);
            return mapper.Map<SightDTOModel>(sight);
        }
        public async Task<SightDTOModel> Delete(int id)
        {
            var sight = repository.GetByIdAsync(id);
            await repository.DeleteAsync(id);
            return mapper.Map<SightDTOModel>(sight);
        }
        public async Task<List<SightDTOModel>> GetAll()
        {
            var sights = await repository.GetAllAsync();
            var sightsDTOList = new List<SightDTOModel>();  
            foreach (var sight in sights)
            {
                sightsDTOList.Add(mapper.Map<Sight, SightDTOModel>(sight));
            }
            return sightsDTOList;
        }
        public async Task<SightDTOModel> GetById(int id)
        {
            var sight = repository.GetByIdAsync(id);
            if (sight == null)
                throw new ValidationException("Sightseeing not found");
            return mapper.Map<SightDTOModel>(sight);
        }
        public async Task<SightDTOModel?> Update(int id, SightDTOModel updateSightDTO)
        {
            var sight = mapper.Map<Sight>(updateSightDTO);
            await repository.UpdateAsync(id, sight);
            return mapper.Map<SightDTOModel>(sight);
        }
    }
}

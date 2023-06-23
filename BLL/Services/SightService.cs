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
    internal class SightService
    {
        private readonly IBaseRepository<Sight> _repository;
        private readonly IMapper _mapper;

        public SightService(IBaseRepository<Sight> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SightDTOModel> Add(SightDTOModel addSightDTO)
        {
            var sight = _mapper.Map<Sight>(addSightDTO);
            await _repository.AddAsync(sight);

            return _mapper.Map<SightDTOModel>(sight);
        }

        public async Task<SightDTOModel> Delete(int id)
        {
            var sight = _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(id);

            return _mapper.Map<SightDTOModel>(sight);
        }

        public async Task<List<SightDTOModel>> GetAll()
        {
            var sights = await _repository.GetAllAsync();
            var sightsDTOList = new List<SightDTOModel>();  
            foreach (var sight in sights)
            {
                sightsDTOList.Add(_mapper.Map<Sight, SightDTOModel>(sight));
            }

            return sightsDTOList;
        }

        public async Task<SightDTOModel> GetById(int id)
        {
            var sight = _repository.GetByIdAsync(id);
            if (sight == null)
            {
                throw new EntityNotFoundException("Sightseeing not found");
            }

            return _mapper.Map<SightDTOModel>(sight);
        }

        public async Task<SightDTOModel?> Update(int id, SightDTOModel updateSightDTO)
        {
            var sight = _mapper.Map<Sight>(updateSightDTO);
            await _repository.UpdateAsync(id, sight);

            return _mapper.Map<SightDTOModel>(sight);
        }
    }
}

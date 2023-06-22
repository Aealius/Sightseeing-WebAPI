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
    internal class GuideTourService
    {
        private readonly IBaseRepository<GuideTour> _repository;
        private readonly IMapper _mapper;

        public GuideTourService(IBaseRepository<GuideTour> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GuideTourDTOModel> Add(GuideTourDTOModel addGuideTourDTO)
        {
            var guideTour = _mapper.Map<GuideTour>(addGuideTourDTO);
            await _repository.AddAsync(guideTour);

            return _mapper.Map<GuideTourDTOModel>(guideTour);
        }

        public async Task<GuideTourDTOModel> Delete(int id)
        {
            var guideTour = _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(id);

            return _mapper.Map<GuideTourDTOModel>(guideTour);
        }

        public async Task<List<GuideTourDTOModel>> GetAll()
        {
            var guideTours = await _repository.GetAllAsync();
            var guideToursDTOList = new List<GuideTourDTOModel>();
            foreach (var guideTour in guideTours)
            {
                guideToursDTOList.Add(_mapper.Map<GuideTour, GuideTourDTOModel>(guideTour));
            }

            return guideToursDTOList;
        }

        public async Task<GuideTourDTOModel> GetById(int id)
        {
            var guideTour = _repository.GetByIdAsync(id);

            return _mapper.Map<GuideTourDTOModel>(guideTour);
        }

        public async Task<GuideTourDTOModel?> Update(int id, GuideTourDTOModel updateGuideTourDTO)
        {
            var guideTour = _mapper.Map<GuideTour>(updateGuideTourDTO);
            await _repository.UpdateAsync(id, guideTour);

            return _mapper.Map<GuideTourDTOModel>(guideTour);
        }
    }
}

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
    internal class GuideTourService
    {
        private readonly BaseRepository<GuideTour> repository;
        private readonly IMapper mapper;
        public GuideTourService(BaseRepository<GuideTour> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<GuideTourDTOModel> Add(GuideTourDTOModel addGuideTourDTO)
        {
            var guideTour = mapper.Map<GuideTour>(addGuideTourDTO);
            await repository.AddAsync(guideTour);
            return mapper.Map<GuideTourDTOModel>(guideTour);
        }
        public async Task<GuideTourDTOModel> Delete(int id)
        {
            var guideTour = repository.GetByIdAsync(id);
            await repository.DeleteAsync(id);
            return mapper.Map<GuideTourDTOModel>(guideTour);
        }
        public async Task<List<GuideTourDTOModel>> GetAll()
        {
            var guideTours = await repository.GetAllAsync();
            var guideToursDTOList = new List<GuideTourDTOModel>();
            foreach (var guideTour in guideTours)
            {
                guideToursDTOList.Add(mapper.Map<GuideTour, GuideTourDTOModel>(guideTour));
            }
            return guideToursDTOList;
        }
        public async Task<GuideTourDTOModel> GetById(int id)
        {
            var guideTour = repository.GetByIdAsync(id);
            if (guideTour == null)
                throw new ValidationException("Guide tour not found");
            return mapper.Map<GuideTourDTOModel>(guideTour);
        }
        public async Task<GuideTourDTOModel?> Update(int id, GuideTourDTOModel updateGuideTourDTO)
        {
            var guideTour = mapper.Map<GuideTour>(updateGuideTourDTO);
            await repository.UpdateAsync(id, guideTour);
            return mapper.Map<GuideTourDTOModel>(guideTour);
        }
    }
}

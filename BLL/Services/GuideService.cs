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
    internal class GuideService
    {
        private readonly BaseRepository<Guide> repository;
        private readonly IMapper mapper;
        public GuideService(BaseRepository<Guide> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<GuideDTOModel> Add(GuideDTOModel guideDTO)
        {
            var guide = mapper.Map<Guide>(guideDTO);
            await repository.AddAsync(guide);
            return mapper.Map<GuideDTOModel>(guide);
        }
        public async Task<GuideDTOModel> Delete(int id)
        {
            var guide = repository.GetByIdAsync(id);
            await repository.DeleteAsync(id);
            return mapper.Map<GuideDTOModel>(guide);
        }
        public async Task<List<GuideDTOModel>> GetAll()
        {
            var guides = await repository.GetAllAsync();
            var guidesDTOList = new List<GuideDTOModel>();
            foreach (var guide in guides)
            {
                guidesDTOList.Add(mapper.Map<Guide, GuideDTOModel>(guide));
            }
            return guidesDTOList;
        }
        public async Task<GuideDTOModel> GetById(int id)
        {
            var guide = repository.GetByIdAsync(id);
            if (guide == null)
                throw new ValidationException("Guide not found");
            return mapper.Map<GuideDTOModel>(guide);
        }
        public async Task<GuideDTOModel?> Update(int id, GuideDTOModel updateGuideDTO)
        {
            var guide = mapper.Map<Guide>(updateGuideDTO);
            await repository.UpdateAsync(id, guide);
            return mapper.Map<GuideDTOModel>(guide);
        }
    }
}

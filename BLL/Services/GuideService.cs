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
    internal class GuideService
    {
        private readonly IBaseRepository<Guide> _repository;
        private readonly IMapper _mapper;

        public GuideService(IBaseRepository<Guide> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GuideDTOModel> Add(GuideDTOModel guideDTO)
        {
            var guide = _mapper.Map<Guide>(guideDTO);
            await _repository.AddAsync(guide);

            return _mapper.Map<GuideDTOModel>(guide);
        }

        public async Task<GuideDTOModel> Delete(int id)
        {
            var guide = _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(id);

            return _mapper.Map<GuideDTOModel>(guide);
        }

        public async Task<List<GuideDTOModel>> GetAll()
        {
            var guides = await _repository.GetAllAsync();
            var guidesDTOList = new List<GuideDTOModel>();
            foreach (var guide in guides)
            {
                guidesDTOList.Add(_mapper.Map<Guide, GuideDTOModel>(guide));
            }

            return guidesDTOList;
        }

        public async Task<GuideDTOModel> GetById(int id)
        {
            var guide = _repository.GetByIdAsync(id);

            return _mapper.Map<GuideDTOModel>(guide);
        }

        public async Task<GuideDTOModel?> Update(int id, GuideDTOModel updateGuideDTO)
        {
            var guide = _mapper.Map<Guide>(updateGuideDTO);
            await _repository.UpdateAsync(id, guide);

            return _mapper.Map<GuideDTOModel>(guide);
        }
    }
}

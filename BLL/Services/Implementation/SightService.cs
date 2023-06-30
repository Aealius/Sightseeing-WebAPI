using Abp.Domain.Entities;
using AutoMapper;
using BLL.Models;
using BLL.Services.Contracts;
using DAL.Entities;
using IUnitOfWork = DAL.UnitOfWork.IUnitOfWork;

namespace BLL.Services.Implementation
{
    public class SightService : ISightService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SightService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(SightDTOModel addSightDTO)
        {
            var sight = _mapper.Map<Sight>(addSightDTO);
            await _unitOfWork.Sights.AddAsync(sight);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(uint id)
        {
            await _unitOfWork.Sights.DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<SightDTOModel>> GetAllAsync()
        {
            var sights = await _unitOfWork.Sights.GetAllAsync();
            var sightsDTOList = new List<SightDTOModel>();
            foreach (var sight in sights)
            {
                sightsDTOList.Add(_mapper.Map<SightDTOModel>(sight));
            }

            return sightsDTOList;
        }

        public async Task<SightDTOModel> GetByIdAsync(uint id)
        {
            var sight = await _unitOfWork.Sights.GetByIdAsync(id);

            if (sight == null)
            {
                throw new EntityNotFoundException("Sightseeing not found");
            }

            var sightDTO = _mapper.Map<SightDTOModel>(sight);

            return sightDTO;
        }

        public async Task UpdateAsync(uint id, SightDTOModel updateSightDTO)
        {
            var sight = _mapper.Map<Sight>(updateSightDTO);
            await _unitOfWork.Sights.UpdateAsync(id, sight);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

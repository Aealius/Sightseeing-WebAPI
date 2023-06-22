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
    internal class RoleService
    {
        private readonly IBaseRepository<Role> _repository;
        private readonly IMapper _mapper;

        public RoleService(IBaseRepository<Role> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RoleDTOModel> Add(RoleDTOModel addRoleDTO)
        {
            var role = _mapper.Map<Role>(addRoleDTO);
            await _repository.AddAsync(role);

            return _mapper.Map<RoleDTOModel>(role);
        }

        public async Task<RoleDTOModel> Delete(int id)
        {
            var role = _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(id);

            return _mapper.Map<RoleDTOModel>(role);
        }

        public async Task<List<RoleDTOModel>> GetAll()
        {
            var roles = await _repository.GetAllAsync();
            var rolesDTOList = new List<RoleDTOModel>();
            foreach (var role in roles)
            {
                rolesDTOList.Add(_mapper.Map<Role, RoleDTOModel>(role));
            }

            return rolesDTOList;
        }

        public async Task<RoleDTOModel> GetById(int id)
        {
            var role = _repository.GetByIdAsync(id);

            return _mapper.Map<RoleDTOModel>(role);
        }

        public async Task<RoleDTOModel?> Update(int id, RoleDTOModel updateRoleDTO)
        {
            var role = _mapper.Map<Role>(updateRoleDTO);
            await _repository.UpdateAsync(id, role);

            return _mapper.Map<RoleDTOModel>(role);
        }
    }
}

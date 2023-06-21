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
    internal class RoleService
    {
        private readonly BaseRepository<Role> repository;
        private readonly IMapper mapper;
        public RoleService(BaseRepository<Role> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<RoleDTOModel> Add(RoleDTOModel addRoleDTO)
        {
            var role = mapper.Map<Role>(addRoleDTO);
            await repository.AddAsync(role);
            return mapper.Map<RoleDTOModel>(role);
        }
        public async Task<RoleDTOModel> Delete(int id)
        {
            var role = repository.GetByIdAsync(id);
            await repository.DeleteAsync(id);
            return mapper.Map<RoleDTOModel>(role);
        }
        public async Task<List<RoleDTOModel>> GetAll()
        {
            var roles = await repository.GetAllAsync();
            var rolesDTOList = new List<RoleDTOModel>();
            foreach (var role in roles)
            {
                rolesDTOList.Add(mapper.Map<Role, RoleDTOModel>(role));
            }
            return rolesDTOList;
        }
        public async Task<RoleDTOModel> GetById(int id)
        {
            var role = repository.GetByIdAsync(id);
            if (role == null)
                throw new ValidationException("Role not found");
            return mapper.Map<RoleDTOModel>(role);
        }
        public async Task<RoleDTOModel?> Update(int id, RoleDTOModel updateRoleDTO)
        {
            var role = mapper.Map<Role>(updateRoleDTO);
            await repository.UpdateAsync(id, role);
            return mapper.Map<RoleDTOModel>(role);
        }
    }
}

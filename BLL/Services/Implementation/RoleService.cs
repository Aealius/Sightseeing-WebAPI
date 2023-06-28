using Abp.Domain.Entities;
using AutoMapper;
using BLL.Models;
using BLL.Services.Contracts;
using DAL.Entities;
using IUnitOfWork = DAL.UnitOfWork.IUnitOfWork;

namespace BLL.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(RoleDTOModel addRoleDTO)
        {
            var role = _mapper.Map<Role>(addRoleDTO);
            await _unitOfWork.Roles.AddAsync(role);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(uint id)
        {
            await _unitOfWork.Roles.DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<RoleDTOModel>> GetAllAsync()
        {
            var roles = await _unitOfWork.Roles.GetAllAsync();
            var rolesDTOList = new List<RoleDTOModel>();
            foreach (var role in roles)
            {
                rolesDTOList.Add(_mapper.Map<RoleDTOModel>(role));
            }

            return rolesDTOList;
        }

        public async Task<RoleDTOModel> GetByIdAsync(uint id)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(id);

            if (role == null)
            {
                throw new EntityNotFoundException("Role not found");
            }

            var roleDTO = _mapper.Map<RoleDTOModel>(role);

            return roleDTO;
        }

        public async Task UpdateAsync(uint id, RoleDTOModel updateRoleDTO)
        {
            var role = _mapper.Map<Role>(updateRoleDTO);
            await _unitOfWork.Roles.UpdateAsync(id, role);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

using Abp.Domain.Entities;
using AutoMapper;
using BLL.Exceptions;
using BLL.Models;
using BLL.Services.Contracts;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using IUnitOfWork = DAL.UnitOfWork.IUnitOfWork;

namespace BLL.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(UserDTOModel addUserDTO)
        {
            var user = _mapper.Map<User>(addUserDTO);
            await _unitOfWork.Users.AddAsync(user);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(uint id)
        {
            await _unitOfWork.Users.DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<UserDTOModel>> GetAllAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            var usersDTOList = new List<UserDTOModel>();
            foreach (var user in users)
            {
                usersDTOList.Add(_mapper.Map<User, UserDTOModel>(user));
            }

            return usersDTOList;
        }

        public async Task<UserDTOModel> GetByIdAsync(uint id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user == null)
            {
                throw new EntityNotFoundException("User not found");
            }

            var userDTO = _mapper.Map<UserDTOModel>(user);

            return userDTO;
        }

        public async Task UpdateAsync(uint id, UserDTOModel updateUserDTO)
        {
            var user = _mapper.Map<User>(updateUserDTO);
            await _unitOfWork.Users.UpdateAsync(id, user);

            await _unitOfWork.SaveChangesAsync();
        }

        public uint GetTokenId(uint id)
        {
            if (_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role) != "admin")
            {
                uint tokenUserId = Convert.ToUInt32(_httpContextAccessor.HttpContext.User.FindFirstValue("UserID"));

                return tokenUserId;
            }
            return 0;
        }
    }
}

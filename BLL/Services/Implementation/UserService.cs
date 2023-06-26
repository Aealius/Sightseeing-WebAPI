using Abp.Domain.Entities;
using AutoMapper;
using BLL.Models;
using BLL.Services.Contracts;
using DAL.Entities;
using IUnitOfWork = DAL.UnitOfWork.IUnitOfWork;

namespace BLL.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(UserDTOModel addUserDTO)
        {
            var user = _mapper.Map<User>(addUserDTO);
            await _unitOfWork.Users.AddAsync(user);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
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

        public async Task<UserDTOModel> GetByIdAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user == null)
            {
                throw new EntityNotFoundException("User not found");
            }

            var userDTO = _mapper.Map<UserDTOModel>(user);

            return userDTO;
        }

        public async Task UpdateAsync(int id, UserDTOModel updateUserDTO)
        {
            var user = _mapper.Map<User>(updateUserDTO);
            await _unitOfWork.Users.UpdateAsync(id, user);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

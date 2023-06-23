using Abp.Domain.Entities;
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
    internal class UserService
    {
        private readonly IBaseRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IBaseRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDTOModel> Add(UserDTOModel addUserDTO)
        {
            var user = _mapper.Map<User>(addUserDTO);
            await _repository.AddAsync(user);

            return _mapper.Map<UserDTOModel>(user);
        }

        public async Task<UserDTOModel> Delete(int id)
        {
            var user = _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(id);

            return _mapper.Map<UserDTOModel>(user);
        }

        public async Task<List<UserDTOModel>> GetAll()
        {
            var users = await _repository.GetAllAsync();
            var usersDTOList = new List<UserDTOModel>();
            foreach (var user in users)
            {
                usersDTOList.Add(_mapper.Map<User, UserDTOModel>(user));
            }

            return usersDTOList;
        }

        public async Task<UserDTOModel> GetById(int id)
        {
            var user = _repository.GetByIdAsync(id);
            if (user == null)
            {
                throw new EntityNotFoundException("User not found");
            }

            return _mapper.Map<UserDTOModel>(user);
        }

        public async Task<UserDTOModel?> Update(int id, UserDTOModel updateUserDTO)
        {
            var user = _mapper.Map<User>(updateUserDTO);
            await _repository.UpdateAsync(id, user);

            return _mapper.Map<UserDTOModel>(user);
        }
    }
}

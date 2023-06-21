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
    internal class UserService
    {
        private readonly BaseRepository<User> repository;
        private readonly IMapper mapper;
        public UserService(BaseRepository<User> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<UserDTOModel> Add(UserDTOModel addUserDTO)
        {
            var user = mapper.Map<User>(addUserDTO);
            await repository.AddAsync(user);
            return mapper.Map<UserDTOModel>(user);
        }
        public async Task<UserDTOModel> Delete(int id)
        {
            var user = repository.GetByIdAsync(id);
            await repository.DeleteAsync(id);
            return mapper.Map<UserDTOModel>(user);
        }
        public async Task<List<UserDTOModel>> GetAll()
        {
            var users = await repository.GetAllAsync();
            var usersDTOList = new List<UserDTOModel>();
            foreach (var user in users)
            {
                usersDTOList.Add(mapper.Map<User, UserDTOModel>(user));
            }
            return usersDTOList;
        }
        public async Task<UserDTOModel> GetById(int id)
        {
            var user = repository.GetByIdAsync(id);
            if (user == null)
                throw new ValidationException("User not found");
            return mapper.Map<UserDTOModel>(user);
        }
        public async Task<UserDTOModel?> Update(int id, UserDTOModel updateUserDTO)
        {
            var user = mapper.Map<User>(updateUserDTO);
            await repository.UpdateAsync(id, user);
            return mapper.Map<UserDTOModel>(user);
        }
    }
}

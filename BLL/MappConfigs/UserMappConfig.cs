using AutoMapper;
using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MappConfigs
{
    internal class UserMappConfig
    {
        private Mapper _UserMapper;
        public UserMappConfig()
        {
            var _configUser = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTOModel>().ReverseMap());
            _UserMapper = new Mapper(_configUser);
        }
    }
}

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
    internal class RoleMappConfig
    {
        private Mapper _RoleMapper;
        public RoleMappConfig()
        {
            var _configRole = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTOModel>().ReverseMap());
            _RoleMapper = new Mapper(_configRole);
        }
    }
}

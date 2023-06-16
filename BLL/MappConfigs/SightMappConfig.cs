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
    internal class SightMappConfig
    {
        private Mapper _SightMapper;
        public SightMappConfig()
        {
            var _configSight = new MapperConfiguration(cfg => cfg.CreateMap<Sight, SightDTOModel>().ReverseMap());
            _SightMapper = new Mapper(_configSight);
        }
    }
}

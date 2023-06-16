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
    internal class GuideMappConfig
    {
        private Mapper _GuideMapper;
        public GuideMappConfig()
        {
            var _configGuide = new MapperConfiguration(cfg => cfg.CreateMap<Guide, GuideDTOModel>().ReverseMap());
            _GuideMapper = new Mapper(_configGuide);
        }
    }
}

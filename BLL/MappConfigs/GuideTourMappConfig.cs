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
    internal class GuideTourMappConfig
    {
        private Mapper _GuideTourMapper;
        public GuideTourMappConfig()
        {
            var _configGuideTour = new MapperConfiguration(cfg => cfg.CreateMap<GuideTour, GuideTourDTOModel>().ReverseMap());
            _GuideTourMapper = new Mapper(_configGuideTour);
        }
    }
}

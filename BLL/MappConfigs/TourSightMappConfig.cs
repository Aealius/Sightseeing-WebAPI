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
    internal class TourSightMappConfig
    {
        private Mapper _TourSightMapper;
        public TourSightMappConfig()
        {
            var _configTourSight = new MapperConfiguration(cfg => cfg.CreateMap<TourSight, TourSightDTOModel>().ReverseMap());
            _TourSightMapper = new Mapper(_configTourSight);
        }
    }
}

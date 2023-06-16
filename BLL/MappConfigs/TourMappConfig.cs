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
    internal class TourMappConfig
    {
        private Mapper _TourMapper;
        public TourMappConfig()
        {
            var _configTour = new MapperConfiguration(cfg => cfg.CreateMap<Tour, TourDTOModel>().ReverseMap());
            _TourMapper = new Mapper(_configTour);
        }
    }
}

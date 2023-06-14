using AutoMapper;
using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MappConfig
    {
        private Mapper _SightMapper;
        private Mapper _TourMapper;
        private Mapper _GuideMapper;
        private Mapper _GuideTourMapper;
        private Mapper _ReviewMapper;
        private Mapper _RoleMapper;
        private Mapper _TicketMapper;
        private Mapper _TourSightMapper;
        private Mapper _UserMapper;
        public MappConfig()
        {
            var _configSight = new MapperConfiguration(cfg => cfg.CreateMap<Sight, SightDTOModel>().ReverseMap());
            _SightMapper = new Mapper(_configSight);
            var _configTour = new MapperConfiguration(cfg => cfg.CreateMap<Tour, TourDTOModel>().ReverseMap());
            _TourMapper = new Mapper(_configTour);
            var _configGuide = new MapperConfiguration(cfg => cfg.CreateMap<Guide, GuideDTOModel>().ReverseMap());
            _GuideMapper = new Mapper(_configGuide);
            var _configGuideTour = new MapperConfiguration(cfg => cfg.CreateMap<GuideTour, GuideTourDTOModel>().ReverseMap());
            _GuideTourMapper = new Mapper(_configGuideTour);
            var _configReview = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewDTOModel>().ReverseMap());
            _GuideMapper = new Mapper(_configReview);
            var _configRole = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTOModel>().ReverseMap());
            _GuideMapper = new Mapper(_configRole);
        }
    }
}

using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.MappConfigs
{
    internal class TourSightMappConfig : Profile
    {
        public TourSightMappConfig()
        {
            CreateMap<TourSight, TourSightDTOModel>().ReverseMap(); 
        }
    }
}

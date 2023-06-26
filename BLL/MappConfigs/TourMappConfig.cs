using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.MappConfigs
{
    internal class TourMappConfig : Profile
    {
        public TourMappConfig()
        {
            CreateMap<Tour, TourDTOModel>(); 
        }
    }
}

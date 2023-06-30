using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.MappConfigs
{
    internal class GuideTourMappConfig : Profile
    {
        public GuideTourMappConfig()
        {
            CreateMap<GuideTour, GuideTourDTOModel>().ReverseMap();
        }
    }
}

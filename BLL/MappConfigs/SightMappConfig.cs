using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.MappConfigs
{
    internal class SightMappConfig : Profile
    {
        public SightMappConfig()
        {
            CreateMap<Sight, SightDTOModel>(); 
        }
    }
}

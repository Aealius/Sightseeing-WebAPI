using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.MappConfigs
{
    internal class GuideMappConfig : Profile
    {
        public GuideMappConfig()
        {
            CreateMap<Guide, GuideDTOModel>(); 
        }
    }
}

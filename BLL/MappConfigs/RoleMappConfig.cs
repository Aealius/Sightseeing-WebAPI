using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.MappConfigs
{
    internal class RoleMappConfig : Profile
    {
        public RoleMappConfig()
        {
            CreateMap<Role, RoleDTOModel>().ReverseMap();
        }
    }
}

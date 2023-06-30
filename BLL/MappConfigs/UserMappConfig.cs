using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.MappConfigs
{
    internal class UserMappConfig : Profile
    {
        public UserMappConfig()
        {
            CreateMap<User, UserDTOModel>().ReverseMap(); 
        }
    }
}

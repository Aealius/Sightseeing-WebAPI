using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.MappConfigs
{
    internal class ReviewMappConfig : Profile
    {
        public ReviewMappConfig()
        {
            CreateMap<Review, ReviewDTOModel>();
        }
    }
}

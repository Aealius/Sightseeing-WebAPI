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
    internal class ReviewMappConfig : Profile
    {
        public ReviewMappConfig()
        {
            CreateMap<Review, ReviewDTOModel>();
        }
    }
}

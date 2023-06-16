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
    internal class ReviewMappConfig
    {
        private Mapper _ReviewMapper;
        public ReviewMappConfig()
        {
            var _configReview = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewDTOModel>().ReverseMap());
            _ReviewMapper = new Mapper(_configReview);
        }
    }
}

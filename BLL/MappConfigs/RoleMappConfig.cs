using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MappConfigs
{
    internal class RoleMappConfig : Profile
    {
        public RoleMappConfig()
        {
            CreateMap<Role, RoleDTOModel>();
        }
    }
}

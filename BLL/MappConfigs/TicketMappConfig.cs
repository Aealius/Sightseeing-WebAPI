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
    internal class TicketMappConfig
    {
        private Mapper _TicketMapper;
        public TicketMappConfig()
        {
            var _configTicket = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTOModel>().ReverseMap());
            _TicketMapper = new Mapper(_configTicket);
        }
    }
}

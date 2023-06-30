using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.MappConfigs
{
    internal class TicketMappConfig : Profile
    {
        public TicketMappConfig()
        {
            CreateMap<Ticket, TicketDTOModel>().ReverseMap(); 
        }
    }
}

using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class TicketService
    {
        private readonly BaseRepository<Ticket> repository;
        private readonly IMapper mapper;
        public TicketService(BaseRepository<Ticket> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<TicketDTOModel> Add(TicketDTOModel addTicketDTO)
        {
            var ticket = mapper.Map<Ticket>(addTicketDTO);
            await repository.AddAsync(ticket);
            return mapper.Map<TicketDTOModel>(ticket);
        }
        public async Task<TicketDTOModel> Delete(int id)
        {
            var ticket = repository.GetByIdAsync(id);
            await repository.DeleteAsync(id);
            return mapper.Map<TicketDTOModel>(ticket);
        }
        public async Task<List<TicketDTOModel>> GetAll()
        {
            var tickets = await repository.GetAllAsync();
            var ticketsDTOList = new List<TicketDTOModel>();
            foreach (var ticket in tickets)
            {
                ticketsDTOList.Add(mapper.Map<Ticket, TicketDTOModel>(ticket));
            }
            return ticketsDTOList;
        }
        public async Task<TicketDTOModel> GetById(int id)
        {
            var ticket = repository.GetByIdAsync(id);
            if (ticket == null)
                throw new ValidationException("Ticket not found");
            return mapper.Map<TicketDTOModel>(ticket);
        }
        public async Task<TicketDTOModel?> Update(int id, TicketDTOModel updateTicketDTO)
        {
            var ticket = mapper.Map<Ticket>(updateTicketDTO);
            await repository.UpdateAsync(id, ticket);
            return mapper.Map<TicketDTOModel>(ticket);
        }
    }
}

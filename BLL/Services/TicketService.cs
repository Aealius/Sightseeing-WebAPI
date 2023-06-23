using Abp.Domain.Entities;
using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class TicketService
    {
        private readonly IBaseRepository<Ticket> _repository;
        private readonly IMapper _mapper;

        public TicketService(IBaseRepository<Ticket> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TicketDTOModel> Add(TicketDTOModel addTicketDTO)
        {
            var ticket = _mapper.Map<Ticket>(addTicketDTO);
            await _repository.AddAsync(ticket);

            return _mapper.Map<TicketDTOModel>(ticket);
        }

        public async Task<TicketDTOModel> Delete(int id)
        {
            var ticket = _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(id);

            return _mapper.Map<TicketDTOModel>(ticket);
        }

        public async Task<List<TicketDTOModel>> GetAll()
        {
            var tickets = await _repository.GetAllAsync();
            var ticketsDTOList = new List<TicketDTOModel>();
            foreach (var ticket in tickets)
            {
                ticketsDTOList.Add(_mapper.Map<Ticket, TicketDTOModel>(ticket));
            }

            return ticketsDTOList;
        }

        public async Task<TicketDTOModel> GetById(int id)
        {
            var ticket = _repository.GetByIdAsync(id);
            if (ticket == null)
            {
                throw new EntityNotFoundException("Ticket not found");
            }

            return _mapper.Map<TicketDTOModel>(ticket);
        }

        public async Task<TicketDTOModel?> Update(int id, TicketDTOModel updateTicketDTO)
        {
            var ticket = _mapper.Map<Ticket>(updateTicketDTO);
            await _repository.UpdateAsync(id, ticket);

            return _mapper.Map<TicketDTOModel>(ticket);
        }
    }
}

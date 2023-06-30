using Abp.Domain.Entities;
using AutoMapper;
using BLL.Models;
using BLL.Services.Contracts;
using DAL.Entities;
using IUnitOfWork = DAL.UnitOfWork.IUnitOfWork;

namespace BLL.Services.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(TicketDTOModel addTicketDTO)
        {
            var ticket = _mapper.Map<Ticket>(addTicketDTO);
            await _unitOfWork.Tickets.AddAsync(ticket);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(uint id)
        {
            await _unitOfWork.Tickets.DeleteAsync(id);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<TicketDTOModel>> GetAllAsync()
        {
            var tickets = await _unitOfWork.Tickets.GetAllAsync();
            var ticketsDTOList = new List<TicketDTOModel>();
            foreach (var ticket in tickets)
            {
                ticketsDTOList.Add(_mapper.Map<Ticket, TicketDTOModel>(ticket));
            }

            return ticketsDTOList;
        }

        public async Task<TicketDTOModel> GetByIdAsync(uint id)
        {
            var ticket = await _unitOfWork.Tickets.GetByIdAsync(id);

            if (ticket == null)
            {
                throw new EntityNotFoundException("Ticket not found");
            }

            var ticketDTO = _mapper.Map<TicketDTOModel>(ticket);

            return ticketDTO;
        }

        public async Task UpdateAsync(uint id, TicketDTOModel updateTicketDTO)
        {
            var ticket = _mapper.Map<Ticket>(updateTicketDTO);
            await _unitOfWork.Tickets.UpdateAsync(id, ticket);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

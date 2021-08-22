using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Training.BusinessObjects;
using TicketBookingSystem.Training.Exceptions;
using TicketBookingSystem.Training.UnitOfWorks;

namespace TicketBookingSystem.Training.Services
{
    public class TicketService : ITicketService
    {

        private readonly ITrainingUnitOfWork _trainingUnitOfWork;

        private readonly IMapper _mapper;


        public TicketService(ITrainingUnitOfWork trainingUnitOfWork, IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _mapper = mapper;

        }

        public void CreateTicket(Ticket ticket)
        {
            if (ticket == null)
                throw new InvalidParameterException("ticket is not provided");
            if (IfDestinationNameAlreadyUsed(ticket.Destination))
                throw new DuplicateNameException("this destination name already used");

            _trainingUnitOfWork.Tickets.Add(_mapper.Map<Entities.Ticket>(ticket));
            _trainingUnitOfWork.Save(); ;


        }

        public void DeleteTicket(int id)
        {
             _trainingUnitOfWork.Tickets.Remove(id);
            _trainingUnitOfWork.Save();


        }

        public Ticket GetTicket(int id)
        {
            var ticket = _trainingUnitOfWork.Tickets.GetById(id);
            if (ticket == null)
                return null;
            return _mapper.Map<Ticket>(ticket);


        }

        public (IList<Ticket> records, int total, int totalDisplay) GetTickets(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var ticketData = _trainingUnitOfWork.Tickets.GetDynamic(
               string.IsNullOrEmpty(searchText) ? null : x => x.Destination.Contains(searchText), sortText,
               string.Empty, pageIndex, pageSize);

            var resultData = (from ticket in ticketData.data
                              select _mapper.Map<Ticket>(ticket)
                             ).ToList();

            return (resultData, ticketData.total, ticketData.totalDisplay);
        }

        public void UpdateTicket(Ticket ticket)
        { 
                if (ticket == null)
                    throw new InvalidOperationException("ticket is missing");

                if (IfDestinationNameAlreadyUsed(ticket.Destination, ticket.Id))
                    throw new DuplicateNameException("this name is already used");


                var ticketEntity = _trainingUnitOfWork.Tickets.GetById(ticket.Id);

                if (ticketEntity != null)
                {
                    _mapper.Map(ticket, ticketEntity);
                    _trainingUnitOfWork.Save();
                }
                else
                    throw new InvalidOperationException("Couldn't found ticket ");
            }
        

        private bool IfDestinationNameAlreadyUsed(string destination) =>
            _trainingUnitOfWork.Tickets.GetCount(x => x.Destination == destination) > 0;

        private bool IfDestinationNameAlreadyUsed(string des, int id) =>
          _trainingUnitOfWork.Tickets.GetCount(x => x.Destination==des && x.Id != id) > 0;
    }
}

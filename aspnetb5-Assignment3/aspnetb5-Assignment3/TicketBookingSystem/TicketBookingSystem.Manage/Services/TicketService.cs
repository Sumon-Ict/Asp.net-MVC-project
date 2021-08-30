using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Manage.BusinessObject;
using TicketBookingSystem.Manage.UnitOfWorks;

namespace TicketBookingSystem.Manage.Services
{
    class TicketService : ITicketService
    {
        private readonly IManageUnitOfWork _manageUnitOfWork;
        public TicketService(IManageUnitOfWork manageUnitOfWork)
        {
            _manageUnitOfWork = manageUnitOfWork;
        }

        public void AddTicket(Ticket ticket)
        {
            try
            {
                _manageUnitOfWork.Tickets.Add(new Entity.Ticket
                {
                    CustomerId = ticket.CustomerId,
                    Destination = ticket.Destination,
                    TicketFee = ticket.TicketFee
                });
                _manageUnitOfWork.Save();
            }
            catch
            {
                throw new Exception("Ticket not added to DB");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _manageUnitOfWork.Tickets.Remove(id);
                _manageUnitOfWork.Save();
            }
            catch
            {
                throw new Exception("Ticket not removed");
            }
        }

        public void EditTicket(Ticket ticket)
        {
            var ticketEntity = _manageUnitOfWork.Tickets.GetById(ticket.Id);
            if (ticketEntity != null)
            {
                ticketEntity.CustomerId = ticket.CustomerId;
                ticketEntity.Destination = ticket.Destination;
                ticketEntity.TicketFee = ticket.TicketFee;
                _manageUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Couldn't find Ticket");
            }
        }

        public Ticket GetTicket(int id)
        {
            var ticketEntity = _manageUnitOfWork.Tickets.GetById(id);
            return new Ticket
            {
                Id = ticketEntity.Id,
                Destination = ticketEntity.Destination,
                TicketFee = ticketEntity.TicketFee,
                CustomerId = ticketEntity.CustomerId
            };
        }

        public (IList<Ticket> records, int total, int totalDisplay) GetTickets(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var ticketsData = _manageUnitOfWork.Tickets.GetDynamic(
                 null, null,
                "Customer", pageIndex, pageSize);
            var resultData = (from ticket in ticketsData.data
                              select new Ticket
                              {
                                  Id = ticket.Id,
                                  TicketFee = ticket.TicketFee,
                                  Destination = ticket.Destination,
                                  CustomerName = ticket.Customer.Name
                                  
                              }).ToList();
            return (resultData, ticketsData.total, ticketsData.totalDisplay);
        }
    }
}

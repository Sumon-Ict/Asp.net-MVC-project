using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Manage.BusinessObject;
using TicketBookingSystem.Manage.Services;

namespace TicketBookingSystem.Web.Areas.Admin.Models
{
    public class EditTicketModel
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Destination { get; set; }
        [Required, Range(50, 1000)]
        public int TicketFee { get; set; }
        public int CustomerId { get; set; }
        private readonly ITicketService _ticketService;
        public EditTicketModel()
        {
            _ticketService = Startup.AutofacContainer.Resolve<ITicketService>();
        }
        public EditTicketModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        internal void LoadModelData(int id)
        {
            var ticket = _ticketService.GetTicket(id);
            Id = ticket.Id;
            Destination = ticket.Destination;
            TicketFee = ticket.TicketFee;
            CustomerId = ticket.CustomerId;
        }

        internal void Edit()
        {
            _ticketService.EditTicket(new Ticket
            {
                Id = Id,
                CustomerId = CustomerId,
                Destination = Destination,
                TicketFee = TicketFee
            }) ;
        }
    }
}

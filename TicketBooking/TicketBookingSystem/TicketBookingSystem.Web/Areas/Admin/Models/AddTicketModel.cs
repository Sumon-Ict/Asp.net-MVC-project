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
    public class AddTicketModel
    {
        [Required, MaxLength(200)]
        public string Destination { get; set; }
        [Required, Range(50, 1000)]
        public int TicketFee { get; set; }
        public int CustomerId { get; set; }
        private readonly ITicketService _ticketService;
        public AddTicketModel()
        {
            _ticketService = Startup.AutofacContainer.Resolve<ITicketService>();
        }
        public AddTicketModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        internal void AddTicket()
        {
            _ticketService.AddTicket(new Ticket
            {
                CustomerId = CustomerId,
                Destination = Destination,
                TicketFee = TicketFee
            });
        }
    }
}

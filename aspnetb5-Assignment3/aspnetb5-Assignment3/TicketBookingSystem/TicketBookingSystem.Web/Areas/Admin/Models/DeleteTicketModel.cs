using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Manage.Services;

namespace TicketBookingSystem.Web.Areas.Admin.Models
{
    public class DeleteTicketModel
    {
        private readonly ITicketService _ticketService;
        public DeleteTicketModel()
        {
            _ticketService = Startup.AutofacContainer.Resolve<ITicketService>();
        }
        public DeleteTicketModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        internal void Delete(int id)
        {
            _ticketService.Delete(id);
        }
    }
}

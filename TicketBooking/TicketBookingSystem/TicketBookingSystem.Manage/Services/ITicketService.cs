using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Manage.BusinessObject;

namespace TicketBookingSystem.Manage.Services
{
    public interface ITicketService
    {
        (IList<Ticket> records, int total, int totalDisplay) GetTickets(
            int pageIndex, int pageSize, string searchText, string sortText);
        void AddTicket(Ticket ticket);
        void Delete(int id);
        Ticket GetTicket(int id);
        void EditTicket(Ticket ticket);
    }
}

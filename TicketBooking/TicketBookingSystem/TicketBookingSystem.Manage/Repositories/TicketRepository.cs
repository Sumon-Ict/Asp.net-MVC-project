using Microsoft.EntityFrameworkCore;
using TicketBookingSystem.Data.Repositories;
using TicketBookingSystem.Manage.Contexts;
using TicketBookingSystem.Manage.Entity;

namespace TicketBookingSystem.Manage.Repositories
{
    public class TicketRepository : Repository<Ticket, int>, ITicketRepository
    {
        public TicketRepository(IManageContext manageContext)
            : base((DbContext)manageContext)
        {

        }
    }
}

using TicketBookingSystem.Data.Repositories;
using TicketBookingSystem.Manage.Entity;

namespace TicketBookingSystem.Manage.Repositories
{
    public interface ITicketRepository : IRepository<Ticket, int>
    {
    }
}

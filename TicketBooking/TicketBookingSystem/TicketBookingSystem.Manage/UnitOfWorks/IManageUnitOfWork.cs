using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Data.UnitOfWorks;
using TicketBookingSystem.Manage.Repositories;

namespace TicketBookingSystem.Manage.UnitOfWorks
{
    public interface IManageUnitOfWork : IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        ITicketRepository Tickets { get; }
    }
}

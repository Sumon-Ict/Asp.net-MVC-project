using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Data.Repositories;
using TicketBookingSystem.Manage.Entity;

namespace TicketBookingSystem.Manage.Repositories
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Data.Repositories;
using TicketBookingSystem.Manage.Contexts;
using TicketBookingSystem.Manage.Entity;

namespace TicketBookingSystem.Manage.Repositories
{
    public class CustomerRepository : Repository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(IManageContext manageContext)
            : base((DbContext)manageContext)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Data.UnitOfWorks;
using TicketBookingSystem.Manage.Contexts;
using TicketBookingSystem.Manage.Repositories;

namespace TicketBookingSystem.Manage.UnitOfWorks
{
    public class ManageUnitOfWork : UnitOfWork, IManageUnitOfWork
    {
        public ManageUnitOfWork(IManageContext manageContext, ICustomerRepository customers, ITicketRepository tickets):
            base((DbContext)manageContext)
        {
            Customers = customers;
            Tickets = tickets;
        }

        public ICustomerRepository Customers { get; private set; }

        public ITicketRepository Tickets { get; private set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Data;
using TicketBookingSystem.Training.Contexts;
using TicketBookingSystem.Training.Repositories;

namespace TicketBookingSystem.Training.UnitOfWorks
{
  public  class TrainingUnitOfWork : UnitOfWork, ITrainingUnitOfWork
    {
        public ICustomerRepository Customers { get; private set; }
        public ITicketRepository Tickets { get; private set; }

        public TrainingUnitOfWork(ITrainingContext context,ICustomerRepository customers
            , ITicketRepository tickets): base((DbContext)context)
        {
            Customers = customers;
            Tickets = tickets;

        }


        
        
    }
}

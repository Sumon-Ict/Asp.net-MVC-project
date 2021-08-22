using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Data;
using TicketBookingSystem.Training.Contexts;
using TicketBookingSystem.Training.Entities;

namespace TicketBookingSystem.Training.Repositories
{
  public class TicketRepository  : Repository<Ticket, int>,  ITicketRepository
    {
        public TicketRepository(ITrainingContext context)
            : base((DbContext)context)
        {


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Data;

namespace TicketBookingSystem.Training.Entities
{
    public class Ticket : IEntity<int>
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public int  Fee { get; set; }



    }
}

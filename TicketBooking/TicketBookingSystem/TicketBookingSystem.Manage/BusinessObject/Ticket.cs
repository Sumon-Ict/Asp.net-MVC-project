using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.Manage.BusinessObject
{
    public class Ticket
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Destination { get; set; }
        public int TicketFee { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Data.Entities;

namespace TicketBookingSystem.Manage.Entity
{
    public class Ticket : IEntity<int>
    {
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [MaxLength(100), Required]
        public string Destination { get; set; }
        public int TicketFee { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Data.Entities;

namespace TicketBookingSystem.Manage.Entity
{
    public class Customer : IEntity<int>
    {
        public int Id { get; set; }
        [MaxLength(256), Required]
        public string Name { get; set; }
        
        public int Age { get; set; }
        [MaxLength(256), Required]
        public string Address { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}

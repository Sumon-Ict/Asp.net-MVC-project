using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Manage.BusinessObject;
using TicketBookingSystem.Manage.Services;

namespace TicketBookingSystem.Web.Areas.Admin.Models
{
    public class AddCustomerModel
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [Required, Range(10, 90)]
        public int Age { get; set; }
        [Required, MaxLength(200)]
        public string Address { get; set; }

        private readonly ICustomerService _customerService;
        public AddCustomerModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
        }
        public AddCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        internal void AddCustomer()
        {
            _customerService.Add(new Customer
            {
                Name = Name,
                Age = Age,
                Address = Address
            });
        }
    }
}

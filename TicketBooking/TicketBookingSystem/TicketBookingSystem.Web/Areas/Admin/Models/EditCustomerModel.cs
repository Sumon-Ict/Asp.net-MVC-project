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
    public class EditCustomerModel
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [Required, Range(10, 90)]
        public int Age { get; set; }
        [Required, MaxLength(200)]
        public string Address { get; set; }

        private readonly ICustomerService _customerService;
        public EditCustomerModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
        }
        public EditCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        internal void LoadModelData(int id)
        {
            var customer = _customerService.GetCustomer(id);
            Id = customer.Id;
            Age = customer.Age;
            Address = customer.Address;
            Name = customer.Name;
        }

        internal void Edit()
        {
            _customerService.Edit(new Customer
            {
                Id = Id,
                Age = Age,
                Address = Address,
                Name = Name,
            });
        }
    }
}

using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Manage.Services;

namespace TicketBookingSystem.Web.Areas.Admin.Models
{
    public class DeleteCustomerModel
    {
        private readonly ICustomerService _customerService;
        public DeleteCustomerModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
        }
        public DeleteCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        internal void Delete(int id)
        {
            _customerService.Delete(id);
        }
    }
}

using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Models;
using TicketBookingSystem.Training.Services;

namespace TicketBookingSystem.Areas.Admin.Models
{
    public class CustomerListModel
    {
        private readonly ICustomerService _customerService;

        public CustomerListModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();

        }

        public CustomerListModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        internal object GetAllCustomer(DataTablesAjaxRequestModel tableModel)
        {


              var data = _customerService.GetCustomers(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name", "Address" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.Address,
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal void delete(int id)
        {
            _customerService.DeleteCustomer(id);

        }
    }
}

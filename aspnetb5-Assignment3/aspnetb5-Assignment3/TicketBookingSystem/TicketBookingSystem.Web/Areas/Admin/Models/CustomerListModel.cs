using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Manage.Services;
using TicketBookingSystem.Web.Models;

namespace TicketBookingSystem.Web.Areas.Admin.Models
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
        internal object GetCustomers(DataTablesAjaxRequestModel dataTablesAjaxRequestModel)
        {
            var data = _customerService.GetCustomers(
                    dataTablesAjaxRequestModel.PageIndex,
                    dataTablesAjaxRequestModel.PageSize,
                    dataTablesAjaxRequestModel.SearchText,
                    dataTablesAjaxRequestModel.GetSortText(new string[] { "Name", "Age", "Address" })
                );
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.Age.ToString(),
                            record.Address,
                            record.Id.ToString()
                        }).ToArray()
            };
        }
    }
}

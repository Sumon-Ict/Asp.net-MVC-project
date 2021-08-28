using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Manage.Services;
using TicketBookingSystem.Web.Models;

namespace TicketBookingSystem.Web.Areas.Admin.Models
{
    public class TicketListModel
    {
        private readonly ITicketService _ticketService;
        public TicketListModel()
        {
            _ticketService = Startup.AutofacContainer.Resolve<ITicketService>();
        }
        public TicketListModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        internal object GetTickets(DataTablesAjaxRequestModel dataTablesAjaxRequestModel)
        {
            var data = _ticketService.GetTickets(
                    dataTablesAjaxRequestModel.PageIndex,
                    dataTablesAjaxRequestModel.PageSize,
                    dataTablesAjaxRequestModel.SearchText,
                    dataTablesAjaxRequestModel.GetSortText(new string[] {})
                );
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.CustomerName,
                            record.Destination,
                            record.TicketFee.ToString(),
                            record.Id.ToString()
                        }).ToArray()
            };
        }
    }
}

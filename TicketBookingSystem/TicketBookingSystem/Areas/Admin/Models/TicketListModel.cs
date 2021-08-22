using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Models;
using TicketBookingSystem.Training.Services;

namespace TicketBookingSystem.Areas.Admin.Models
{
    public class TicketListModel
    {
        private readonly ITicketService _ticketService;

        private readonly IMapper _mapper;


        public TicketListModel()
        {
            _ticketService = Startup.AutofacContainer.Resolve<ITicketService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();


        }

        public TicketListModel(ITicketService ticketService,IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;

        }

        internal object gettickets(DataTablesAjaxRequestModel tableModel)
        {


            var data = _ticketService.GetTickets(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Destination", "Fee" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Destination,
                                record.Fee.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        public void delete(int id)
        {
            _ticketService.DeleteTicket(id);

        }

    }
}

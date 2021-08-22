using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Training.BusinessObjects;
using TicketBookingSystem.Training.Services;

namespace TicketBookingSystem.Areas.Admin.Models
{
    public class CreateTicketModel
    {
        [Required, MaxLength(200, ErrorMessage = "Destination name should be less than 200 charcaters")]
        public string Destination { get; set; }
        [Required,Range(10,900000)]
        public int Fee { get; set; }


        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public CreateTicketModel()
        {
            _ticketService = Startup.AutofacContainer.Resolve<ITicketService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }
        public CreateTicketModel(ITicketService ticketService,IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }

        public void createticket()
        {
            var ticket = _mapper.Map<Ticket>(this);

            _ticketService.CreateTicket(ticket);
        }

    }
}

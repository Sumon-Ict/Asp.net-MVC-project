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
    public class EditTicketModel
    {
        public int Id { get; set; }
        [Required,MaxLength(100,ErrorMessage ="destination name must be less than 100 characters")]
        public string Destination { get; set; }

        [Required,Range(10,7899990)]
        public int Fee { get; set; }
        private readonly ITicketService _ticketService;

        private readonly IMapper _mapper;


        public EditTicketModel()
        {
            _ticketService = Startup.AutofacContainer.Resolve<ITicketService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }
        public EditTicketModel(ITicketService ticketService, IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }

        public void LoadModelData(int id)
        {
            var ticket = _ticketService.GetTicket(id);

            _mapper.Map(ticket, this);

        }
        public void UpdateTicket()
        {
            var ticket = _mapper.Map<Ticket>(this);

            _ticketService.UpdateTicket(ticket);


        }


    }
}

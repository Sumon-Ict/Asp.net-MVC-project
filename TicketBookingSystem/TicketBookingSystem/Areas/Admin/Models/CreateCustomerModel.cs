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
    public class CreateCustomerModel
    {
        [Required, MaxLength(200, ErrorMessage = "Customer name should be less than 200 charcaters")]
        public string Name { get; set; }

        [Required,MaxLength(100,ErrorMessage ="Address should be less than 100 character")]
        public string Address { get; set; }

        private readonly ICustomerService _customerService;

        private readonly IMapper _mapper;
        public CreateCustomerModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }
        public CreateCustomerModel(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        internal void CreateNewCustomer()
        {
            var customer = _mapper.Map<Customer>(this);

            _customerService.CreateCustomer(customer);


        }





    }

}

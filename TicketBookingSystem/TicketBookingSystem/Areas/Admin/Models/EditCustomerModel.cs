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
    public class EditCustomerModel
    {

        public int Id { get; set; }

        [Required, MaxLength(200, ErrorMessage = "Customer name should be less than 200 charcaters")]
        public string Name { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Address should be less than 100 character")]
        public string Address { get; set; }


        private readonly ICustomerService _customerService;

        private readonly IMapper _mapper;

        public EditCustomerModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }

        public EditCustomerModel(ICustomerService customerService,IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        internal void LoadModelData(int id)
        {
            var customer = _customerService.GetCustomer(id);

            _mapper.Map(customer, this);

        }

        internal void UpDateCustomer()
        {
          var customer=  _mapper.Map<Customer>(this);

            _customerService.UpdateCustomer(customer);

        }
    }
}

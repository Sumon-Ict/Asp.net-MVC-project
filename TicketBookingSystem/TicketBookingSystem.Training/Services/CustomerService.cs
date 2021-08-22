using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Training.BusinessObjects;
using TicketBookingSystem.Training.Exceptions;
using TicketBookingSystem.Training.UnitOfWorks;

namespace TicketBookingSystem.Training.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(ITrainingUnitOfWork trainingUnitOfWork, IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _mapper = mapper;

        }
  

        public void CreateCustomer(Customer customer)
        {
            if (customer == null)
                throw new InvalidParameterException("customer is not provided");

            if (IfNameAlreadyUsed(customer.Name))

                throw new DuplicateNameException("this name is already exits");

            _trainingUnitOfWork.Customers.Add(_mapper.Map<Entities.Customer>(customer));
            _trainingUnitOfWork.Save();

        }

        public void DeleteCustomer(int id)
        {
            _trainingUnitOfWork.Customers.Remove(id);
            _trainingUnitOfWork.Save();

        }

        public Customer GetCustomer(int id)
        {
            var customer = _trainingUnitOfWork.Customers.GetById(id);
            if (customer == null)
                return null;

           return  _mapper.Map<Customer>(customer);

        }

      
            public (IList<Customer> records, int total, int totalDisplay) GetCustomers(int pageIndex,
                int pageSize, string searchText, string sortText)
            {
                var customerData = _trainingUnitOfWork.Customers.GetDynamic(
                     string.IsNullOrEmpty(searchText) ? null : x => x.Name.Contains(searchText),
                     sortText,
                     string.Empty, pageIndex, pageSize);

                var resultData = (from customer in customerData.data
                                  select _mapper.Map<Customer>(customer)
                                 ).ToList();

                return (resultData, customerData.total, customerData.totalDisplay);

            }
  

        public void UpdateCustomer(Customer customer)
        {
            if (customer== null)
                throw new InvalidOperationException("Customer is missing");

            if (IfNameAlreadyUsed(customer.Name, customer.Id))
                throw new DuplicateNameException("this name is already used");


            var customerEntity = _trainingUnitOfWork.Customers.GetById(customer.Id);

            if (customerEntity != null)
            {
                _mapper.Map(customer, customerEntity);
                _trainingUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Couldn't found customer ");
        }

        private bool IfNameAlreadyUsed(string name)=>
            _trainingUnitOfWork.Customers.GetCount(x => x.Name == name) > 0;

        private bool IfNameAlreadyUsed(string name, int id) =>
            _trainingUnitOfWork.Customers.GetCount(x => x.Name == name && x.Id != id) > 0;

            

        
    }
}

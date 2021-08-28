using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Manage.BusinessObject;
using TicketBookingSystem.Manage.UnitOfWorks;

namespace TicketBookingSystem.Manage.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IManageUnitOfWork _manageUnitOfWork;
        public CustomerService(IManageUnitOfWork manageUnitOfWork)
        {
            _manageUnitOfWork = manageUnitOfWork;
        }

        public void Add(Customer customer)
        {
            try
            {
                _manageUnitOfWork.Customers.Add(new Entity.Customer
                {
                    Name = customer.Name,
                    Age = customer.Age,
                    Address = customer.Address
                });
                _manageUnitOfWork.Save();
            }
            catch
            {
                throw new Exception("Customer not added to db");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _manageUnitOfWork.Customers.Remove(id);
                _manageUnitOfWork.Save();
            }
            catch
            {
                throw new Exception("Customer not removed");
            }
        }

        public void Edit(Customer customer)
        {

            var customerEntity = _manageUnitOfWork.Customers.GetById(customer.Id);
            if (customerEntity != null)
            {
                customerEntity.Name = customer.Name;
                customerEntity.Age = customer.Age;
                customerEntity.Address = customer.Address;
                _manageUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Couldn't find Customer");
            }
        }

        public (IList<Customer> records, int total, int totalDisplay) GetCustomers(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var customersData = _manageUnitOfWork.Customers.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText), sortText,
                "", pageIndex, pageSize);
            var resultData = (from customer in customersData.data
                              select new Customer
                              {
                                  Id = customer.Id,
                                  Name = customer.Name,
                                  Age = customer.Age,
                                  Address = customer.Address
                              }).ToList();
            return (resultData, customersData.total, customersData.totalDisplay);
        }

        public Customer GetCustomer(int id)
        {
            var customerEntity = _manageUnitOfWork.Customers.GetById(id);
            return new Customer
            {
                Id = customerEntity.Id,
                Name = customerEntity.Name,
                Address = customerEntity.Address,
                Age = customerEntity.Age
            };
        }
    }
}

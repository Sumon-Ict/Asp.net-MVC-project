using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Training.BusinessObjects;

namespace TicketBookingSystem.Training.Services
{
   public interface ICustomerService
    {
        void CreateCustomer(Customer customer);
        (IList<Customer> records, int total, int totalDisplay) GetCustomers(int pageIndex, int pageSize,
           string searchText, string sortText);
        Customer GetCustomer(int id);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}

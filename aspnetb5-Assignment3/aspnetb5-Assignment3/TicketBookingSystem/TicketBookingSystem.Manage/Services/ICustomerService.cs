using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Manage.BusinessObject;

namespace TicketBookingSystem.Manage.Services
{
    public interface ICustomerService
    {
        (IList<Customer> records, int total, int totalDisplay) GetCustomers(
            int pageIndex, int pageSize, string searchText, string sortText);
        void Add(Customer customer);
        void Delete(int id);
        Customer GetCustomer(int id);
        void Edit(Customer customer);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Training.BusinessObjects;

namespace InventorySystem.Training.Services
{
   public interface IProductService
    {
        //void CreateCustomer(Customer customer)

        //(IList<Customer> records, int total, int totalDisplay) GetCustomers(int pageIndex, int pageSize,
        //   string searchText, string sortText);
        //Customer GetCustomer(int id);
        //void UpdateCustomer(Customer customer);
        //void DeleteCustomer(int id);

        void CreateProduct(Product product);
        (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex, int pageSize,
         string searchText, string sortText);


        Product GetProduct(int id);

        void UpdateProduct(Product product);
        void DeleteProduct(int id);


    }
}

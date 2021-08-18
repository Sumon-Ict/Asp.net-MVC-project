using ECommerceSystem.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Training.Services
{
  public  interface IProductService
    {

       // IList<Product> GetAllProduct();     
        void CreateProduct(Product product);
        (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex, int pageSize,
           string searchText, string sortText);
        Product GetProduct(int id);
        void UpdateProduct(Product course);
        void DeleteProduct(int id);


    }
}

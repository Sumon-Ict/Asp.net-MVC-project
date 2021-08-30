using ECommerceSystem.Inventory.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Inventory.Services
{
    public interface IProductService
    {
        (IList<Product> records, int total, int totalDisplay) GetProducts(
            int pageIndex, int pageSize, string searchText, string sortText);
        void AddProduct(Product product);
        Product GetProduct(int id);
        void EditProduct(Product product);
        void DeleteProduct(int id);
    }
}

using ECommerceSystem.Inventory.BusinessObject;
using ECommerceSystem.Inventory.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Inventory.Services
{
    public class ProductService : IProductService
    {
        private readonly IInventoryUnitOfWork _inventoryUnitOfWork;
        public ProductService(IInventoryUnitOfWork inventoryUnitOfWork)
        {
            _inventoryUnitOfWork = inventoryUnitOfWork;
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new InvalidOperationException("Product was not provided!");
            if (IsNameAlreadyUsed(product.Name))
            {
                throw new Exception("Product already exists");
            }
            if (!IsPriceInRange(product.Price))
            {
                throw new Exception("Price is not in range");
            }
            else
            {
                _inventoryUnitOfWork.Products.Add(
                new Entities.Product
                {
                    Name = product.Name,
                    Price = product.Price
                });
                _inventoryUnitOfWork.Save();
            }
        }

        public (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var productsData = _inventoryUnitOfWork.Products.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText), sortText,
                string.Empty, pageIndex, pageSize);
            var resultData = (from product in productsData.data
                              select new Product
                              {
                                  Id = product.Id,
                                  Name = product.Name,
                                  Price = product.Price
                              }).ToList();
            return (resultData, productsData.total, productsData.totalDisplay);

        }        

        public Product GetProduct(int id)
        {
            var product = _inventoryUnitOfWork.Products.GetById(id);
            if (product == null)
                return null;
            return new Product { Id = product.Id, Name = product.Name, Price = product.Price };
        }

        public void EditProduct(Product product)
        {
            if(product == null)
            {
                throw new InvalidOperationException("Product is missing");
            }
            if(IsNameAlreadyUsed(product.Name, product.Id))
            {
                throw new Exception("Duplicate product already in the database");
            }
            var productEntity = _inventoryUnitOfWork.Products.GetById(product.Id);
            if(productEntity != null)
            {
                productEntity.Name = product.Name;
                productEntity.Price = product.Price;
                _inventoryUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Couldn't find product");
            }
        }
        public void DeleteProduct(int id)
        {
            _inventoryUnitOfWork.Products.Remove(id);
            _inventoryUnitOfWork.Save();
        }
        private bool IsNameAlreadyUsed(string title) =>
            _inventoryUnitOfWork.Products.GetCount(x => x.Name == title) > 0;
        private bool IsNameAlreadyUsed(string title, int id) =>
            _inventoryUnitOfWork.Products.GetCount(x => x.Name == title && x.Id != id) > 0;
        private bool IsPriceInRange(double price)
        {
            if (price >= 1 && price <= 100000)
                return true;
            return false;
        }
    }
}

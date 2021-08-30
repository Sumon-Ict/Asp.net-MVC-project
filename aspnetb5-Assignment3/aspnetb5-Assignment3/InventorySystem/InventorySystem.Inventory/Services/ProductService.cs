using InventorySystem.Inventory.BusinessObject;
using InventorySystem.Inventory.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Inventory.Services
{
    public class ProductService : IProductService
    {
        private readonly IInventoryUnitOfWork _inventoryUnitOfWork;
        public ProductService(IInventoryUnitOfWork inventoryUnitOfWork)
        {
            _inventoryUnitOfWork = inventoryUnitOfWork;
        }
        public (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var productsData = _inventoryUnitOfWork.Products.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText), sortText,
                "Stock", pageIndex, pageSize);
            var resultData = (from product in productsData.data
                              select new Product
                              {
                                  Id = product.Id,
                                  Name = product.Name,
                                  Price = product.Price,
                                  Quantity = product.Stock !=null ? product.Stock.Quantity : 0
                              }).ToList();
            return (resultData, productsData.total, productsData.totalDisplay);
        }
        public Product GetProduct(int id)
        {
            var product = _inventoryUnitOfWork.Products.GetById(id);
            if (product == null)
                return null;
            var quantityEntityList = _inventoryUnitOfWork.Stocks.GetDynamic(s => s.ProductId == product.Id, null, "", false);
            var quantityEntity = quantityEntityList.Count>0 ? quantityEntityList[0] : new Entities.Stock { Quantity = 0 };
            return new Product { Id = product.Id, Name = product.Name, Price = product.Price, Quantity = quantityEntity.Quantity };
        }

        public void EditProduct(Product product)
        {
            if (product == null)
            {
                throw new InvalidOperationException("Product is missing");
            }
            if (IsNameAlreadyUsed(product.Name, product.Id))
            {
                throw new Exception("Duplicate product already in the database");
            }
            var productEntity = _inventoryUnitOfWork.Products.GetById(product.Id);
            if (productEntity != null)
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
        public int AddProduct(Product product)
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
                var newObject = new Entities.Product
                {
                    Name = product.Name,
                    Price = product.Price
                };
                _inventoryUnitOfWork.Products.Add(newObject);
                _inventoryUnitOfWork.Save();
                var id = newObject.Id;
                return id;
            }
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

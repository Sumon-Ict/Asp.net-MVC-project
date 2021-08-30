using Autofac;
using InventorySystem.Inventory.BusinessObject;
using InventorySystem.Inventory.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.web.Areas.Admin.Models
{
    public class AddProductModel
    {
        [Required, MaxLength(200, ErrorMessage = "Name must be less than 200 characters")]
        public string Name { get; set; }
        [Required, Range(1, 100000, ErrorMessage = "Price must be between 1 - 100000")]
        public double Price { get; set; }
        [Required, Range(1, 1000, ErrorMessage = "Quantity must be between 1 - 1000")]
        public int Quantity { get; set; }
        private readonly IProductService _productService;
        public AddProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
        }
        public AddProductModel(IProductService productService)
        {
            _productService = productService;
        }

        internal void AddProduct()
        {
            var ProductId = _productService.AddProduct(new Product
            {
                Name = Name,
                Price = Price,
            });
            var stockModel = new AddStockModel();
            stockModel.ProductId = ProductId;
            stockModel.Quantity = Quantity;
            stockModel.AddStock();
            
        }
    }
}

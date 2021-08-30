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
    public class EditProductModel
    {
        public int? Id { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Name must be less than 200 characters")]
        public string Name { get; set; }
        [Required, Range(1, 100000, ErrorMessage = "Price must be between 1 - 100000")]
        public double? Price { get; set; }
        private readonly IProductService _productService;
        [Required, Range(1, 1000, ErrorMessage = "Quantity must be between 1 - 1000")]
        public int Quantity { get; set; }
        public EditProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
        }
        public EditProductModel(IProductService productService)
        {
            _productService = productService;
        }
        public void LoadModelData(int id)
        {
            var product = _productService.GetProduct(id);
            Id = product?.Id;
            Name = product?.Name;
            Price = product?.Price;
            Quantity = product.Quantity;
        }
        internal void Edit()
        {
            _productService.EditProduct(new Product
            {
                Id = Id.HasValue ? Id.Value : 0,
                Name = Name,
                Price = Price.HasValue ? Price.Value : 0
            });
            var editStock = new EditStockModel();
            editStock.ProductId = Id.HasValue ? Id.Value : 0;
            editStock.Quantity = Quantity;
            editStock.EditStock();
        }
    }
}

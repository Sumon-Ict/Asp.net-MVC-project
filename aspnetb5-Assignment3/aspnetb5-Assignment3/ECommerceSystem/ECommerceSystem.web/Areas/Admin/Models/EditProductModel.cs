using Autofac;
using ECommerceSystem.Inventory.BusinessObject;
using ECommerceSystem.Inventory.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSystem.web.Areas.Admin.Models
{
    public class EditProductModel
    {
        public int? Id { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Name must be less than 200 characters")]
        public string Name { get; set; }
        [Required, Range(1, 100000, ErrorMessage = "Price must be between 1 - 100000")]
        public double ? Price { get; set; }
        private readonly IProductService _productService;
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
        }
        internal void Edit()
        {
            _productService.EditProduct(new Product
            {
                Id = Id.HasValue ? Id.Value : 0,
                Name = Name,
                Price = Price.HasValue ? Price.Value : 0
            });
        }
    }
}

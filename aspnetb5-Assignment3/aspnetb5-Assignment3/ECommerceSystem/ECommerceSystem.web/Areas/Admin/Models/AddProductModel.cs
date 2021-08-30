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
    public class AddProductModel
    {
        [Required, MaxLength(200, ErrorMessage = "Name must be less than 200 characters")]
        public string Name { get; set; }
        [Required, Range(1, 100000, ErrorMessage = "Price must be between 1 - 100000")]
        public double Price { get; set; }
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
            _productService.AddProduct(new Product
            { 
                Name = Name,
                Price = Price
            });
        }
    }
}

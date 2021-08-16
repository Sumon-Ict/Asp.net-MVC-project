using Autofac;
using ECommerceSystem.Training.BusinessObjects;
using ECommerceSystem.Training.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSystem.Areas.Admin.Models
{
    public class CreateProductModel
    {
        [Required, MaxLength(200, ErrorMessage = "Product name should be less than 200 charcaters")]
        public string Name { get; set; }
        [Required, Range(100, 50000)]
        public int Price { get; set; }
        

        private readonly IProductService _productService;

        public CreateProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
        }
        public CreateProductModel(IProductService productService)
        {
            _productService = productService;
        }

        internal void CreateProduct()
        {
            var product = new Product
            {
                Name=Name,
                Price=Price
            };
            _productService.CreateProduct(product);

        }
    }
}

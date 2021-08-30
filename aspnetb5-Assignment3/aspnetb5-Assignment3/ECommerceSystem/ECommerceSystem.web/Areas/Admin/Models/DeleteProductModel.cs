using Autofac;
using ECommerceSystem.Inventory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSystem.web.Areas.Admin.Models
{
    public class DeleteProductModel
    {
        public int ? Id { get; set; }
        private readonly IProductService _productService;
        public DeleteProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
        }
        public DeleteProductModel(IProductService productService)
        {
            _productService = productService;
        }
        public void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}

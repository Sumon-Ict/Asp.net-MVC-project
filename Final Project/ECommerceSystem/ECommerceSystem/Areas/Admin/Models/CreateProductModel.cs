using Autofac;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public CreateProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }
        public CreateProductModel(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        internal void CreateProduct2()    
        {
            var product = _mapper.Map<Product>(this);

            _productService.CreateProduct(product);

        }
    }
}

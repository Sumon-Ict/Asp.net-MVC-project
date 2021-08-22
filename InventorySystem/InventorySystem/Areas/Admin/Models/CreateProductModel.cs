using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using InventorySystem.Training.BusinessObjects;
using InventorySystem.Training.Services;

namespace InventorySystem.Areas.Admin.Models
{
    public class CreateProductModel
    {    
       
        [Required,MaxLength(100,ErrorMessage ="product name must be less than 100 characters")]
        public string Name { get; set; }

        [Required,Range(20,2000000)]
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

        public void createProduct()
        {
            var product = _mapper.Map<Product>(this);

            _productService.CreateProduct(product);


        }




    }
}

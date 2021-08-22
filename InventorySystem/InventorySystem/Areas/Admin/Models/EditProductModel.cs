using AutoMapper;
using InventorySystem.Training.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using InventorySystem.Training.BusinessObjects;

namespace InventorySystem.Areas.Admin.Models
{
    public class EditProductModel
    {
        public int Id { get; set; }

      [Required,MaxLength(100,ErrorMessage ="product name must be less than 100 characters")]
        public string Name { get; set; }

        [Required,Range(20,289000)]
        public int Price { get; set; }

        private readonly IProductService _productService;

        private readonly IMapper _mapper;

        public EditProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();


        }

        public EditProductModel(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;

        }

        public void LoadModelData(int id)
        {
            var product = _productService.GetProduct(id);

            _mapper.Map(product, this);

        }

        public void updateProduct()
        {
            var product = _mapper.Map<Product>(this);

            _productService.UpdateProduct(product);

        }





    }
}

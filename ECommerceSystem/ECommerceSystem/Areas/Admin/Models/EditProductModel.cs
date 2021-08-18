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
    public class EditProductModel
    {
        [Required, Range(1, 5000)]
        public int Id { get; set; }

        [Required, MaxLength(200, ErrorMessage = "product name  should be less than 200 charcaters")]
        public string Name { get; set; }

        [Required, Range(100, 500000)]
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

            _mapper.Map(product, this);   //values copies product into this class object 


            //Id = product.Id;
            //Name = product.Name;
            //Price = product.Price;

        }

        internal void Update()
        {

            var product = new Product();

            _mapper.Map(this, product);  ///  _mapper.Map<Product>(this);  same work 

            _productService.UpdateProduct(product);
        }
    }
}

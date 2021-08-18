using AutoMapper;
using ECommerceSystem.Training.BusinessObjects;
using ECommerceSystem.Training.Exceptions;
using ECommerceSystem.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Training.Services
{
    public class ProductService : IProductService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        public readonly IMapper _mapper;

       
        public ProductService(ITrainingUnitOfWork trainingUnitOfWork,IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _mapper = mapper;

        }


        public void CreateProduct(Product product)
        {
            if (product == null)
                throw new InvalidParameterException("product was not provided");

            if (IsNameAlreadyUsed(product.Name))

                throw new DuplicateNameException(" product  name already exits");


            if (!IsNameAlreadyUsed(product.Name))
            {

                _trainingUnitOfWork.Products.Add(
                   _mapper.Map<Entities.Product>(product));              
                _trainingUnitOfWork.Save();
            }
        }
         
      /*  public IList<Product> GetAllProduct()
        {
            var productEntities = _trainingUnitOfWork.Products.GetAll();

            var products = new List<Product>();

            foreach (var entity in productEntities)
            {
                var product = new Product()
                {
                    Id = entity.Id,
                    Name=entity.Name,
                    Price=entity.Price                  

                };
                products.Add(product);

            }
            return products;
         } */

        public Product GetProduct(int id)
        {
            var product = _trainingUnitOfWork.Products.GetById(id);

            if (product == null) return null;

            return _mapper.Map<Product>(product);
        }


        public (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var productData = _trainingUnitOfWork.Products.GetDynamic(
                 string.IsNullOrEmpty(searchText) ? null : x => x.Name.Contains(searchText), sortText,
                 string.Empty, pageIndex, pageSize);

            var resultData = (from product in productData.data
                              select _mapper.Map<Product>(product)
                             ).ToList();

            return (resultData, productData.total, productData.totalDisplay);

        }


        public void UpdateProduct(Product product)
        {
            if (product == null)
                throw new InvalidOperationException("product is missing");

            if (IsNameAlreadyUsed(product.Name, product.Id))
                throw new DuplicateNameException("product name is already used in other course");

            var productEntity = _trainingUnitOfWork.Products.GetById(product.Id);

            if (productEntity != null)
            {
                _mapper.Map(product, productEntity);  //copies values of product into productEntity 
                          

                _trainingUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("product could not found");
        }
        public void DeleteProduct(int id)
        {
            _trainingUnitOfWork.Products.Remove(id);
            _trainingUnitOfWork.Save();

        }
        private bool IsNameAlreadyUsed(string name) =>
            _trainingUnitOfWork.Products.GetCount(x => x.Name == name) > 0;
        private bool IsNameAlreadyUsed(string name, int id) =>
           _trainingUnitOfWork.Products.GetCount(x => x.Name == name && x.Id != id) > 0;

    }
}

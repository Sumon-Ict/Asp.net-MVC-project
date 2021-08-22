using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Training.BusinessObjects;
using InventorySystem.Training.Exceptions;
using InventorySystem.Training.UnitOfWorks;

namespace InventorySystem.Training.Services
{
    public class ProductService : IProductService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IMapper _mapper;

        public ProductService(ITrainingUnitOfWork trainingUnitOfWork, IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _mapper = mapper;

        }


        public void CreateProduct(Product product)
        {
            if (product == null)
                throw new InvalidParameterException("product is not provided");

            if (IfNameAlreadyUsed(product.Name))

                throw new DuplicateNameException("this name is already exits");

            _trainingUnitOfWork.Products.Add(_mapper.Map<Entities.Product>(product));
            _trainingUnitOfWork.Save();

        }    

        public void DeleteProduct(int id)
        {
            _trainingUnitOfWork.Products.Remove(id);
            _trainingUnitOfWork.Save();

        }    

        public Product GetProduct(int id)
        {
            var product = _trainingUnitOfWork.Products.GetById(id);
            if (product == null)
                return null;

           return  _mapper.Map<Product>(product);

        }


        public (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex,
            int pageSize, string searchText, string sortText)
        {
                var productData = _trainingUnitOfWork.Products.GetDynamic(
                     string.IsNullOrEmpty(searchText) ? null : x => x.Name.Contains(searchText),
                     sortText,
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

            if (IfNameAlreadyUsed(product.Name, product.Id))
                throw new DuplicateNameException("this name is already used");


            var productEntity = _trainingUnitOfWork.Products.GetById(product.Id);

            if (productEntity != null)
            {
                _mapper.Map(product, productEntity);
                _trainingUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Couldn't found product ");
        }    

        private bool IfNameAlreadyUsed(string name)=>
            _trainingUnitOfWork.Products.GetCount(x => x.Name == name) > 0;

        private bool IfNameAlreadyUsed(string name, int id) =>
            _trainingUnitOfWork.Products.GetCount(x => x.Name == name && x.Id != id) > 0;

            

        
    }
}

using Autofac;
using ECommerceSystem.Models;
using ECommerceSystem.Training.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSystem.Areas.Admin.Models
{
    public class ProductListModel
    {
        private IProductService _productService;

        private IHttpContextAccessor _httpContextAccessor;



        public ProductListModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }
        public ProductListModel(IProductService productService, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
        }


        internal object GetProducts(DataTablesAjaxRequestModel tableModel)
        {


            var data = _productService.GetProducts(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name", "Price" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.Price.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        } 


        internal void Delete(int id)
        {
            _productService.DeleteProduct(id);

        }
    }
}

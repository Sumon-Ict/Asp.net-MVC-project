using Autofac;
using InventorySystem.Inventory.BusinessObject;
using InventorySystem.Inventory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.web.Areas.Admin.Models
{
    public class AddStockModel
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        private readonly IStockService _stockService;
        public AddStockModel()
        {
            _stockService = Startup.AutofacContainer.Resolve<IStockService>();
        }
        public AddStockModel(IStockService stockService)
        {
            _stockService = stockService;
        }
        internal void AddStock()
        {
            _stockService.AddStock(new Stock
            {
                ProductId = ProductId,
                Quantity = Quantity
            });
        }
    }
}

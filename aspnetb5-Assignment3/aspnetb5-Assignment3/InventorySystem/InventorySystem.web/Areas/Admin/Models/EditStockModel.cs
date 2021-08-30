using Autofac;
using InventorySystem.Inventory.BusinessObject;
using InventorySystem.Inventory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.web.Areas.Admin.Models
{
    public class EditStockModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int sellQuantity { get; set; }
        public int ProductId { get; set; }
        private readonly IStockService _stockService;
        public EditStockModel()
        {
            _stockService = Startup.AutofacContainer.Resolve<IStockService>();
        }
        public EditStockModel(IStockService stockService)
        {
            _stockService = stockService;
        }
        internal void EditStock()
        {
            _stockService.EditStock(new Stock
            {
                ProductId = ProductId,
                Quantity = Quantity
            }) ;
        }
        public void LoadModelData(int id)
        {
            var stock = _stockService.GetStock(id);
            Id = stock.Id;
            Quantity = stock.Quantity;
            ProductId = stock.ProductId;
        }

        internal void Sell()
        {
            if (sellQuantity <= Quantity)
            {
                _stockService.EditStock(new Stock
                {
                    ProductId = ProductId,
                    Quantity = Quantity - sellQuantity 
                });
            }
            else
            {
                throw new Exception("Not enough stock to sell");
            }
        }

        internal void Buy()
        {
            _stockService.EditStock(new Stock
            {
                ProductId = ProductId,
                Quantity = Quantity + sellQuantity
            });
        }
    }
}

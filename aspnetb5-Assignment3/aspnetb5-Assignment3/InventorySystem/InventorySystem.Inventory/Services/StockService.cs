using InventorySystem.Inventory.BusinessObject;
using InventorySystem.Inventory.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Inventory.Services
{
    public class StockService : IStockService
    {
        private readonly IInventoryUnitOfWork _inventoryUnitOfWork;
        public StockService(IInventoryUnitOfWork inventoryUnitOfWork)
        {
            _inventoryUnitOfWork = inventoryUnitOfWork;
        }

        public void AddStock(Stock stock)
        {
            try
            {
                _inventoryUnitOfWork.Stocks.Add(new Entities.Stock
                {
                    ProductId = stock.ProductId,
                    Quantity = stock.Quantity
                });
                _inventoryUnitOfWork.Save();
            }
            catch
            {
                throw new Exception("Stock is not added");
            }
        }

        public void EditStock(Stock stock)
        {
            var stockEntityList = _inventoryUnitOfWork.Stocks.GetDynamic(s => s.ProductId == stock.ProductId, null, "", false);
            for(var i=0; i<1 && stockEntityList.Count>0; i++)
            {
                stockEntityList[i].Quantity = stock.Quantity;
                _inventoryUnitOfWork.Save();
            }
            if (stockEntityList.Count < 1)
            {
                var productEntity = _inventoryUnitOfWork.Products.GetById(stock.ProductId);
                if(productEntity != null)
                {
                    AddStock(stock);
                }
                
            }
            
        }

        public Stock GetStock(int id)
        {
            var stockEntity = _inventoryUnitOfWork.Stocks.GetById(id);
            return new Stock { Id = stockEntity.Id, ProductId = stockEntity.ProductId, Quantity = stockEntity.Quantity };
        }

        public (IList<Stock> records, int total, int totalDisplay) GetStocks(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var stocksData = _inventoryUnitOfWork.Stocks.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.ProductId == int.Parse(searchText.Trim()), sortText,
                "Product", pageIndex, pageSize);
            var resultData = (from product in stocksData.data
                              select new Stock
                              {
                                  Id = product.Id,
                                  Quantity = product.Quantity,
                                  ProductId = product.ProductId
                                  
                              }).ToList();
            return (resultData, stocksData.total, stocksData.totalDisplay);
        }
    }
}

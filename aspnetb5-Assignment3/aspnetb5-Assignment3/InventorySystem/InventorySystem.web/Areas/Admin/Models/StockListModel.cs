using Autofac;
using InventorySystem.Inventory.Services;
using InventorySystem.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.web.Areas.Admin.Models
{
    public class StockListModel
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        private readonly IStockService _stockService;
        public StockListModel()
        {
            _stockService = Startup.AutofacContainer.Resolve<IStockService>();
        }
        public StockListModel(IStockService stockService)
        {
            _stockService = stockService;
        }

        internal object GetStocks(DataTablesAjaxRequestModel tableModel)
        {
            var data = _stockService.GetStocks(
                    tableModel.PageIndex,
                    tableModel.PageSize,
                    tableModel.SearchText,
                    tableModel.GetSortText(new string[] { "ProductId"})
                );
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.ProductId.ToString(),
                            record.Quantity.ToString(),
                            record.Id.ToString()
                        }).ToArray()
            };
        }

    }
}

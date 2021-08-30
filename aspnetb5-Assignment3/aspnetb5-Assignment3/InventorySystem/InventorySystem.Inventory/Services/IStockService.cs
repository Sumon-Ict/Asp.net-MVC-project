using InventorySystem.Inventory.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Inventory.Services
{
    public interface IStockService
    {
        void AddStock(Stock stock);
        public void EditStock(Stock stock);
        (IList<Stock> records, int total, int totalDisplay) GetStocks(
            int pageIndex, int pageSize, string searchText, string sortText);
        Stock GetStock(int id);
    }
}

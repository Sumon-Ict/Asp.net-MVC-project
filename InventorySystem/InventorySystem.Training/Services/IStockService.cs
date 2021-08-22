using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Training.BusinessObjects;

namespace InventorySystem.Training.Services
{
    public interface IStockService
    {
       
       // (IList<Stock> records, int total, int totalDisplay) GetStocks(int pageIndex, int pageSize,
         // string searchText, string sortText);
        

        void CreateStock(Stock stock);
        Stock GetStock(int id);
       // void UpdateStock(Stock stock);
        void DeleteStock(int id);


    }
}

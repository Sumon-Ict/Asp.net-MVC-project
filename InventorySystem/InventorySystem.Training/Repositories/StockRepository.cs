using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Data;
using InventorySystem.Training.Contexts;
using InventorySystem.Training.Entities;


namespace InventorySystem.Training.Repositories
{
  public class StockRepository  : Repository<Stock, int>,  IStockRepository
    {
        public StockRepository(ITrainingContext context)
            : base((DbContext)context)
        {


        }
    }
}

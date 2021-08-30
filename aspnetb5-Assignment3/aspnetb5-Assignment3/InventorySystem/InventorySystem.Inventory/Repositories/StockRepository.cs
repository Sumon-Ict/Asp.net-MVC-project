using InventorySystem.Data.Repositories;
using InventorySystem.Inventory.Context;
using InventorySystem.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Inventory.Repositories
{
    public class StockRepository: Repository<Stock, int>, IStockRepository
    {
        public StockRepository(IInventoryContext inventoryContext)
            : base((DbContext)inventoryContext)
        {

        }
    }
}

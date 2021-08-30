using InventorySystem.Data.UnikOfWorks;
using InventorySystem.Inventory.Context;
using InventorySystem.Inventory.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Inventory.UnitOfWorks
{
    public class InventoryUnitOfWork : UnitOfWork, IInventoryUnitOfWork
    {
        public IProductRepository Products { get; private set; }
        public IStockRepository Stocks { get; private set; }
        public InventoryUnitOfWork(IInventoryContext inventoryContext, IProductRepository product, IStockRepository stock) :
            base((DbContext)inventoryContext)
        {
            Products = product;
            Stocks = stock;
        }

    }
}

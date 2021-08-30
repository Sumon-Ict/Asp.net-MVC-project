using ECommerceSystem.Data.UnitOfWorks;
using ECommerceSystem.Inventory.Context;
using ECommerceSystem.Inventory.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Inventory.UnitOfWorks
{
    public class InventoryUnitOfWork : UnitOfWork, IInventoryUnitOfWork
    {
        public IProductRepository Products { get; private set; }
        public InventoryUnitOfWork(IInventoryContext inventoryContext, IProductRepository product):
            base((DbContext)inventoryContext)
        {
            Products = product;
        }
    }
}

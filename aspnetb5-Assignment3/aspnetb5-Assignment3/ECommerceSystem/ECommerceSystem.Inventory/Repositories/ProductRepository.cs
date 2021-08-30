using ECommerceSystem.Data.Repositories;
using ECommerceSystem.Inventory.Context;
using ECommerceSystem.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Inventory.Repositories
{
    public class ProductRepository: Repository<Product, int>, 
        IProductRepository
    {
        public ProductRepository(IInventoryContext inventoryContext)
            : base((DbContext)inventoryContext)
        {

        }
    }
}

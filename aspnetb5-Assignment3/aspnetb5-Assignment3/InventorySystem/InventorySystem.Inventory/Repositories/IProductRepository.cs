﻿using InventorySystem.Data.Repositories;
using InventorySystem.Inventory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Inventory.Repositories
{
    public interface IProductRepository : IRepository<Product, int>
    {
    }
}

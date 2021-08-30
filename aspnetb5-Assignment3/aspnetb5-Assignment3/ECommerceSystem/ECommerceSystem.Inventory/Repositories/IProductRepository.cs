using ECommerceSystem.Data.Repositories;
using ECommerceSystem.Inventory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Inventory.Repositories
{
    public interface IProductRepository : IRepository<Product, int>
    {
    }
}

using ECommerceSystem.Data.UnitOfWorks;
using ECommerceSystem.Inventory.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Inventory.UnitOfWorks
{
    public interface IInventoryUnitOfWork : IUnitOfWork
    {
        IProductRepository Products { get; }
    }
}

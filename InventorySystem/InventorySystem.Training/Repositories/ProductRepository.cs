using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Data;
using InventorySystem.Training.Contexts;
using InventorySystem.Training.Entities;
using InventorySystem.Training.Repositories;

namespace InventorySystem.Training.Repositories
{
  public  class ProductRepository :  Repository<Product ,int >, IProductRepository
    {
        public ProductRepository(ITrainingContext context)
            : base((DbContext)context)
            {

            }
    }
}

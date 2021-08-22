using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Data;
using InventorySystem.Training.Contexts;
using InventorySystem.Training.Repositories;

namespace InventorySystem.Training.UnitOfWorks
{
  public  class TrainingUnitOfWork : UnitOfWork, ITrainingUnitOfWork
    {
        public IProductRepository Products { get; private set; }
        public IStockRepository Stocks { get; private set; }

        public TrainingUnitOfWork(ITrainingContext context, IProductRepository products
            , IStockRepository stocks) : base((DbContext)context)
        {
            Products = products;
            Stocks = stocks;

        }


        
        
    }
}

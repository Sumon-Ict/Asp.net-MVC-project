using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Data;
using InventorySystem.Training.Repositories;

namespace InventorySystem.Training.UnitOfWorks
{
   public interface ITrainingUnitOfWork : IUnitOfWork
    {
       IProductRepository Products { get; }
        IStockRepository Stocks { get; }

    }
}

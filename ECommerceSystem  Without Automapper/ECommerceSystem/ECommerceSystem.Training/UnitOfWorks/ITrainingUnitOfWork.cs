using ECommerceSystem.Data;
using ECommerceSystem.Training.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Training.UnitOfWorks
{
  public  interface ITrainingUnitOfWork : IUnitOfWork
    {
     public  IProductRepository Products { get; }
    }
}

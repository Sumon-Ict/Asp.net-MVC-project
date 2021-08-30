using Autofac;
using ECommerceSystem.Inventory.Context;
using ECommerceSystem.Inventory.Repositories;
using ECommerceSystem.Inventory.Services;
using ECommerceSystem.Inventory.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.Inventory
{
    public class InventoryModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public InventoryModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InventoryContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope(); // Rakhte hobe. for migration
            builder.RegisterType<InventoryContext>().As<IInventoryContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();
            //builder.RegisterType<CourseService>().As<ICourseService>().InstancePerLifetimeScope();
            builder.RegisterType<InventoryUnitOfWork>().As<IInventoryUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            base.Load(builder);
        }

    }
}

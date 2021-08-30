using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBookingSystem.Manage.Contexts;
using TicketBookingSystem.Manage.Repositories;
using TicketBookingSystem.Manage.Services;
using TicketBookingSystem.Manage.UnitOfWorks;

namespace TicketBookingSystem.Manage
{
    public class ManageModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public ManageModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ManageContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope(); 
            builder.RegisterType<ManageContext>().As<IManageContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();
            builder.RegisterType<ManageUnitOfWork>().As<IManageUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TicketRepository>().As<ITicketRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerLifetimeScope();
            builder.RegisterType<TicketService>().As<ITicketService>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}

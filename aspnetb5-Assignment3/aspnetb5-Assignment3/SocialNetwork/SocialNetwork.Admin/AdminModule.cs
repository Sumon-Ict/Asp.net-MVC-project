using Autofac;
using SocialNetwork.Admin.Contexts;
using SocialNetwork.Admin.Repositories;
using SocialNetwork.Admin.Services;
using SocialNetwork.Admin.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Admin
{
    public class AdminModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public AdminModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AdminDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();
            builder.RegisterType<AdminDbContext>().As<IAdminDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();
            builder.RegisterType<AdminUnitOfWork>().As<IAdminUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<MemberRepository>().As<IMemberRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PhotoRepository>().As<IPhotoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MemberService>().As<IMemberService>().InstancePerLifetimeScope();
            builder.RegisterType<PhotoService>().As<IPhotoService>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}

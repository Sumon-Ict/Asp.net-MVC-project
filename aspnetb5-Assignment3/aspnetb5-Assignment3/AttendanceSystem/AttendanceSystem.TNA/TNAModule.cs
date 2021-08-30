using AttendanceSystem.TNA.Contexts;
using AttendanceSystem.TNA.Repositories;
using AttendanceSystem.TNA.Services;
using AttendanceSystem.TNA.UnitOfWorks;
using Autofac;


namespace AttendanceSystem.TNA
{
    public class TNAModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public TNAModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TNADbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();
            builder.RegisterType<TNADbContext>().As<ITNADbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();
            builder.RegisterType<TNAUnitOfWork>().As<ITNAUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AttendanceRepository>().As<IAttendanceRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();
            builder.RegisterType<AttendanceService>().As<IAttendanceService>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}

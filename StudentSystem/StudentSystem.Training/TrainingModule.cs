using Autofac;
using StudentSystem.Training.Contexts;
using StudentSystem.Training.Repositories;
using StudentSystem.Training.Services;
using StudentSystem.Training.UnitOfWorks;
using System;

namespace StudentSystem.Training
{
    public class TrainingModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public TrainingModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<TrainingDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<TrainingDbContext>().As<ITrainingDbContext>()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("migrationAssemblyName", _migrationAssemblyName)
               .InstancePerLifetimeScope();



            builder.RegisterType<StudentRepository>().As<IStudentRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TrainingUnitOfWork>().As<ITrainingUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentService>().As<IStudentService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}

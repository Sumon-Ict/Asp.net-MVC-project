using Autofac;
using MVCFirstDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFirstDemo
{
    public class WebModule : Module
    {


        protected override void Load(ContainerBuilder builder)
        {
           // builder.RegisterType<SimpleDatabaseService>().As<IDatabaseService>()
              //   .InstancePerLifetimeScope();
            builder.RegisterType<AdvanceDatabaseService>().As<IDatabaseService>()
                .InstancePerLifetimeScope();

 
            base.Load(builder);
        }
    }
}

using Autofac;
using BookSystem.Common.Utility;
using System;

namespace BookSystem.Common
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<DateTimeUtility>().As<IDateTimeUtility>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}

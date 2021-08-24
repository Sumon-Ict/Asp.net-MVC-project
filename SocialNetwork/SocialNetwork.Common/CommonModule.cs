using System;
using Autofac;
using SocialNetwork.Common.Utilities;

namespace SocialNetwork.Common
{
    public  class CommonModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DateTimeUtility>().As<IDateTimeUtility>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}

using Autofac;
using FirstDemo.Common.Utilities;

namespace FirstDemo.Common
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

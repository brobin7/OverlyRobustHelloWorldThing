using Autofac;
using HelloWorld.Interfaces;

namespace HelloWorld.DependancyInjection
{
    public class ConnectionFactoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ConnectionFactory>()
                .As<IConnectionFactory>();
        }
    }
}

using Autofac;
using HelloWorld.Interfaces;

namespace HelloWorld.DependancyInjection
{
    public class RoboCommunicatorFactoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<RoboCommunicatorFactory>()
                .As<ICommunicatorFactory>();
        }
    }
}

using Autofac;
using HelloWorld.Interfaces;

namespace HelloWorld.DependancyInjection
{
    public class RoboCommunicatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<RoboDbCommunicator>()
                .As<IDbCommunicator>();
        }
    }
}

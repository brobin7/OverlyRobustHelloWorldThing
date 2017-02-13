using Autofac;
using HelloWorld.Interfaces;

namespace HelloWorld.DependancyInjection
{
    public class MrRobotoModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<MrRoboto>()
                .As<IRobot>();
        }
    }
}

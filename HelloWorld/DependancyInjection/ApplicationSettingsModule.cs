using Autofac;
using HelloWorld.Interfaces;

namespace HelloWorld.DependancyInjection
{
    public class ApplicationSettingsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            
            builder.RegisterType<BasicApplicationSettings>()
                .As<ISqlCommunicationSettings>()
                .InstancePerLifetimeScope();
        }
    }
}

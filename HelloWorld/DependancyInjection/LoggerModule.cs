using Autofac;
using NLog;

namespace HelloWorld.DependancyInjection
{
    public class LoggerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(resolver => LogManager.GetCurrentClassLogger())
                .As<ILogger>();
        }
    }
}

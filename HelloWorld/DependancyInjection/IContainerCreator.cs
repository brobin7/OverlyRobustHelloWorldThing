using Autofac;
using Owin;

namespace HelloWorld.DependancyInjection
{
    public interface IContainerCreator
    {
        ContainerBuilder CreateContainer(IAppBuilder app);
    }
}

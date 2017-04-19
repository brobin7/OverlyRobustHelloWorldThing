using HelloWorld.DependancyInjection;

namespace HelloWorld.Api
{
    public class StartupDependencies
    {
        public IContainerCreator RuntimeDependencies { get; set; }
    }
}
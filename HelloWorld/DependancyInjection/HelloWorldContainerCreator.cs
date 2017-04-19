using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.DependancyInjection
{
    public class HelloWorldContainerCreator : ContainerCreatorBase
    {
        protected RoboCommunicatorModule RobComModule { get; } = new RoboCommunicatorModule();
        protected RoboCommunicatorFactory RobFacModule { get; } = new RoboCommunicatorFactory();
        protected ConnectionFactoryModule ConFacModule { get; } = new ConnectionFactoryModule();
        protected LoggerModule LogModule { get; } = new LoggerModule();
        protected MrRobotoModule RobModule { get; } = new MrRobotoModule();

    }
}

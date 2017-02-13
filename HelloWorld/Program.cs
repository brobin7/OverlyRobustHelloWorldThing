using System.Reflection;
using Autofac;
using HelloWorld.Interfaces;
using NLog;

namespace HelloWorld
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            using (var appContainer = containerBuilder.Build())
            {
              var logger =  appContainer.Resolve<ILogger>();
              logger.Info("Robot's first program!");

              var robot = appContainer.Resolve<IRobot>();
              robot.Greeting();
            }
        }
    }
}

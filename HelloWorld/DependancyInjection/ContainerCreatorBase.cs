using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Owin;
using Module = Autofac.Module;

namespace HelloWorld.DependancyInjection
{
    public class ContainerCreatorBase : IContainerCreator
    {
        public ContainerBuilder CreateContainer(IAppBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var builder = new ContainerBuilder();
            var thisType = GetType();
            var properties = thisType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var property in properties)
            {
                if (typeof(Module).IsAssignableFrom(property.PropertyType))
                {
                    var module = (Module)property.GetValue(this);
                    builder.RegisterModule(module);
                }
            }

            return builder;
        }
    }
}

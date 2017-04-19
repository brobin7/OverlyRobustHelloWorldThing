using Autofac.Integration.WebApi;
using System;
using System.Reflection;
using System.Web.Http;
using HelloWorld.DependancyInjection;
using HelloWorld.Interfaces;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(HelloWorld.Api.Startup))]

namespace HelloWorld.Api
{
    public partial class Startup
    {
        private readonly ISqlCommunicationSettings m_settings;
        private readonly StartupDependencies m_startupDependencies;

        public Startup() : this(new BasicApplicationSettings(), new StartupDependencies { RuntimeDependencies = new HelloWorldContainerCreator()})
        { }

        public Startup(ISqlCommunicationSettings settings, StartupDependencies dependencies)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (dependencies == null)
            {
                throw new ArgumentNullException(nameof(dependencies));
            }

            m_settings = settings;
            m_startupDependencies = dependencies;
        }


        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.Map(new PathString("/api/hello"), SetupHelloApi);
            
        }

        private void SetupHelloApi(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            var containerBuilder = m_startupDependencies.RuntimeDependencies.CreateContainer(app);
            var config = new HttpConfiguration();
            
            containerBuilder.RegisterWebApiFilterProvider(config);
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = containerBuilder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
    }
}

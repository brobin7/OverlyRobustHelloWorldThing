using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;

namespace HelloWorld.Api
{
    /// <summary>
    /// Resolves routes which exist on base classes and only exposes them if the current controller inherits from a specific base controller.
    /// </summary>
    /// <typeparam name="TBaseController"></typeparam>
    public class TypedDirectRouteProvider<TBaseController> : DefaultDirectRouteProvider
		where TBaseController : IHttpController
    {
        /// <inheritDoc/>
		[SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "Validated by check.")]
        public override IReadOnlyList<RouteEntry> GetDirectRoutes(
			HttpControllerDescriptor controllerDescriptor,
			IReadOnlyList<HttpActionDescriptor> actionDescriptors,
			IInlineConstraintResolver constraintResolver)
        {

			if (typeof (TBaseController).IsAssignableFrom(controllerDescriptor.ControllerType))
			{
				var routes = base.GetDirectRoutes(controllerDescriptor, actionDescriptors, constraintResolver);
				return routes;
			}

			return new RouteEntry[0];
		}

        /// <inheritDoc/>
		protected override IReadOnlyList<IDirectRouteFactory> GetActionRouteFactories(HttpActionDescriptor actionDescriptor)
		{
			// inherit route attributes decorated on base class controller's actions
			IReadOnlyList<IDirectRouteFactory> list = new ArraySegment<IDirectRouteFactory>();
			return actionDescriptor == null ? list : actionDescriptor.GetCustomAttributes<IDirectRouteFactory>(inherit: true);
		}
	}
}
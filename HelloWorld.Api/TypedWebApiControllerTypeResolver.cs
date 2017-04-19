using System;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace HelloWorld.Api
{
    /// <summary>
    /// Resolves controllers which explicitly can be assigned from a base class type.
    /// </summary>
    /// <typeparam name="TBaseController"></typeparam>
	public class TypedWebApiControllerTypeResolver<TBaseController> : DefaultHttpControllerTypeResolver
		where TBaseController : IHttpController
	{
        /// <summary>
        /// Creates a new instance of <see cref="TypedWebApiControllerTypeResolver{TBaseController}"/>
        /// </summary>
		public TypedWebApiControllerTypeResolver()
			: base(IsDashboardController)
		{
		}

		private static bool IsDashboardController(Type type)
		{
			return
				type.IsClass &&
				type.IsVisible &&
				!type.IsAbstract &&
				typeof (TBaseController).IsAssignableFrom(type);
		}
	}
}
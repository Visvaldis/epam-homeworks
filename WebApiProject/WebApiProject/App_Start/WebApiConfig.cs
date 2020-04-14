using BLL.Infrastructure;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiProject.Util;

namespace WebApiProject
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Конфигурация и службы веб-API
			//NinjectModule orderModule = new OrderModule();
			//NinjectModule productModule = new ProductModule();
			//NinjectModule serviceModule = new ServiceModule("WebApiContext");
			//var kernel = new StandardKernel(orderModule, productModule, serviceModule);
			//config.DependencyResolver = new NinjectResolver(kernel);

			// Маршруты веб-API
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
			config.Formatters.JsonFormatter
				.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
			config.Formatters.JsonFormatter
				.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream"));

		}
	}
}

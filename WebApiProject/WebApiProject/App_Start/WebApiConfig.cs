using Autofac;
using Autofac.Integration.WebApi;
using BLL.Infrastructure;
using BLL.Services;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using WebApiProject.Util;

namespace WebApiProject
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Конфигурация и службы веб-API

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
		/*
		public static void ConfigComponents(HttpConfiguration config)
		{
			var builder = new ContainerBuilder();

			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			builder.RegisterType<ProductService>().AsImplementedInterfaces().InstancePerRequest();

			builder.RegisterType<UnitOfWork>


		}*/
	}
}

using BLL.Infrastructure;
using Ninject;
using Ninject.Modules;
using Ninject.Web.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApiProject.Util;

namespace WebApiProject
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{

			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

		
			
			//внедрение зависимостей
			NinjectModule orderModule = new OrderModule();
			NinjectModule productModule = new ProductModule();
			NinjectModule serviceModule = new ServiceModule("WebApiContext");
			var kernel = new StandardKernel(orderModule, productModule, serviceModule);

			GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
			


		}
	}
}

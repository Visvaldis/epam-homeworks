using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services;
using Ninject.Modules;
using BLL.Interfaces;

namespace PL_Console.Util
{
	class ProductModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IProductService>().To<ProductService>();
		}
	}
}

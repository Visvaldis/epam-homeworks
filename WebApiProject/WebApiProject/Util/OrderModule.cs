using System.Web;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;

namespace WebApiProject.Util
{
	public class OrderModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IOrderService>().To<OrderService>();
		}
	}
}
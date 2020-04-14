using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class OrderService : IOrderService
	{
		IUnitOfWork Database { get; set; }
		IMapper Mapper { get; set; }

		public OrderService(IUnitOfWork uow)
		{
			Database = uow;
			Mapper = new MapperConfiguration(cfg => {
				cfg.CreateMap<Order, OrderDTO>();
				cfg.CreateMap<OrderDTO, Order>();

				cfg.CreateMap<Product, ProductDTO>();
				cfg.CreateMap<ProductDTO, Product>();
			})
			.CreateMapper();
		}
		public void Add(OrderDTO item)
		{
			if (item == null)
				throw new ArgumentNullException("Current order is null. Try again.");

			var tag = Database.Orders.Find(x => x.Name.ToLower() == item.Name.ToLower());
			if (tag.ToList().Count == 0)
			{
				Database.Orders.Create(Mapper.Map<OrderDTO, Order>(item));
				Database.Save();
			}
		}

		public void Delete(int id)
		{
			Database.Orders.Delete(id);
			Database.Save();
		}

		public void Dispose()
		{
			Database.Dispose();
		}

		public OrderDTO Get(int id)
		{
			var order = Database.Orders.Get(id);
			if (order == null)
				throw new ValidationException("Current order is not found");

			return Mapper.Map<Order, OrderDTO>(order);
		}

		public IEnumerable<OrderDTO> GetAll()
		{
			return Mapper.Map<IEnumerable<Order>, List<OrderDTO>>(Database.Orders.GetAll());
		}

		public IEnumerable<ProductDTO> GetAllProductsByOrder(int id)
		{
			var products = Database.Orders.Get(id).Products;
			return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(products);
		}

		public IEnumerable<OrderDTO> GetWithFilter(Func<OrderDTO, bool> filter)
		{
			var mapper = new MapperConfiguration(
			cfg => cfg.CreateMap<Func<OrderDTO, bool>,
			Expression<Func<Order, bool>>>())
				.CreateMapper();

			var expression = mapper.Map<Expression<Func<Order, bool>>>(filter);


			return Mapper.Map<IEnumerable<Order>, List<OrderDTO>>
				(Database.Orders.Find(expression).ToList());
		}

		public void Update(OrderDTO item)
		{
			Database.Orders.Update(Mapper.Map<OrderDTO, Order>(item));
			Database.Save();
		}

		public void AddProductToOrder(int orderId, int productId)
		{
			var prod = Database.Products.Get(productId);
			var order = Database.Orders.Get(orderId);
			order.Products.ToList().Add(prod);
			Database.Save();
		}
	}
}

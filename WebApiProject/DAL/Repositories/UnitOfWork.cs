using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		public UnitOfWork(string connectionString)
		{
			db = new OrderContext(connectionString);
		}
		private OrderContext db;
		private OrderRepository orderRepository;
		private ProductRepository productRepository;
		public IRepository<Product> Products
		{
			get
			{
				if (productRepository == null)
					productRepository = new ProductRepository(db);
				return productRepository;
			}
		}

		public IRepository<Order> Orders
		{
			get
			{
				if (orderRepository == null)
					orderRepository = new OrderRepository(db);
				return orderRepository;
			}
		}
		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			throw new NotImplementedException();
		}
	}
}

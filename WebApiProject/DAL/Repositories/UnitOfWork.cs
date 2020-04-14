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
		private bool disposed = false;

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					db.Dispose();
				}
				this.disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public void Save()
		{
			db.SaveChanges();
		}
	}
}

using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	class OrderRepository : IRepository<Order>
	{
		private OrderContext db { get; set; }

		public OrderRepository(OrderContext context)
		{
			this.db = context;
		}

		public void Create(Order item)
		{
			db.Orders.Add(item);
		}

		public void Delete(int id)
		{
			Order order = db.Orders.Find(id);
			if (order != null)
				db.Orders.Remove(order);
		}

		public IQueryable<Order> Find(Expression<Func<Order, bool>> predicate)
		{
			return db.Orders.Include(x => x.Products).Where(predicate);
		}

		public Order Get(int id)
		{
			return db.Orders.Include(x => x.Products).FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Order> GetAll()
		{
			return db.Orders;
		}

		public void Update(Order item)
		{
			db.Orders.Attach(item);
			db.Entry(item).State = EntityState.Modified;
		}
	}
}

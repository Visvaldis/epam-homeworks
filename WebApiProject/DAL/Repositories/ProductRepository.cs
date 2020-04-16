using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
	class ProductRepository :IRepository<Product>
	{
		private OrderContext db { get; set; }
		public ProductRepository(OrderContext context)
		{
			this.db = context;
		}
		public int Create(Product item)
		{
			var prod = db.Products.Add(item);
			return prod.Id;
		}

		public void Delete(int id)
		{
			Product author = db.Products.Find(id);
			if (author != null)
				db.Products.Remove(author);
		}

		public IQueryable<Product> Find(Expression<Func<Product, bool>> predicate)
		{
			return db.Products.Where(predicate);
		}

		public Product Get(int id)
		{
			return db.Products.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Product> GetAll()
		{
			return db.Products;
		}

		public void Update(Product item)
		{
			db.Products.Attach(item);
			db.Entry(item).State = EntityState.Modified;
		}

	}
}

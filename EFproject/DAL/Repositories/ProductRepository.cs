using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;
using DAL.EF;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DAL.Repositories
{
	class ProductRepository : IRepository<Product>
	{
		private ProductsContext db;
		public ProductRepository(ProductsContext context)
		{
			this.db = context;
		}

		public void Create(Product item)
		{
			db.Products.Add(item);
		}

		public void Delete(int id)
		{
			Product product = db.Products.Find(id);
			if (product != null)
				db.Products.Remove(product);
		}

		public IQueryable<Product> Find(Expression<Func<Product, Boolean>> predicate)
		{
			return db.Products
				.Include(x => x.Category).Include(x => x.Supplier)
				.Where(predicate);
		}

		//ASK
		public Product Get(int id)
		{
			return db.Products.Include(x => x.Category).Include(x => x.Supplier).Where(x => x.Id == id).First();
				
		}

		public IEnumerable<Product> GetAll()
		{
			return db.Products.Include(x => x.Category).Include(x => x.Supplier);
		}

		//ASK
		public void Update(Product item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}

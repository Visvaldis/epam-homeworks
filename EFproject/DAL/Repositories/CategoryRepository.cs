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
	class CategoryRepository : IRepository<Category>
	{
		private ProductsContext db;
		public CategoryRepository(ProductsContext context)
		{
			this.db = context;
		}

		public void Create(Category item)
		{
			db.Categories.Add(item);
		}

		public void Delete(int id)
		{
			Category category = db.Categories.Find(id);
			if (category != null)
				db.Categories.Remove(category);
		}

		public IQueryable<Category> Find(Expression<Func<Category, Boolean>> predicate)
		{
			return db.Categories.Where(predicate);
		}

		public Category Get(int id)
		{
			return db.Categories.Find(id);
		}

		public IEnumerable<Category> GetAll()
		{
			return db.Categories;
		}

		public void Update(Category item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}

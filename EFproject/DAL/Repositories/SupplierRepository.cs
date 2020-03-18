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
	class SupplierRepository : IRepository<Supplier>
	{
		private ProductsContext db;
		public SupplierRepository(ProductsContext context)
		{
			this.db = context;
		}

		public void Create(Supplier item)
		{
			db.Suppliers.Add(item);
		}

		public void Delete(int id)
		{
			Supplier supplier = db.Suppliers.Find(id);
			if (supplier != null)
				db.Suppliers.Remove(supplier);
		}

		public IQueryable<Supplier> Find(Expression<Func<Supplier, bool>> predicate)
		{
			return db.Suppliers.Where(predicate);
		}

		public Supplier Get(int id)
		{
			return db.Suppliers.Find(id);
		}

		public IEnumerable<Supplier> GetAll()
		{
			return db.Suppliers.Include(s => s.Products);
		}

		public void Update(Supplier item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}

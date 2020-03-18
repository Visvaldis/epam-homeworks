using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;
using DAL.EF;
using System.Data.Entity;

namespace DAL.Repositories
{
	public class EFUnitOfWork : IUnitOfWork
	{
		private ProductsContext db;
		private ProductRepository productRepository;
		private CategoryRepository categoryRepository;
		private SupplierRepository supplierRepository;

		public EFUnitOfWork(string connectionString)
		{
			db = new ProductsContext(connectionString);
		}
		public IRepository<Product> Products
		{
			get
			{
				if (productRepository == null)
					productRepository = new ProductRepository(db);
				return productRepository;
			}
		}

		public IRepository<Category> Categories
		{
			get
			{
				if (categoryRepository == null)
					categoryRepository = new CategoryRepository(db);
				return categoryRepository;
			}
		}

		public IRepository<Supplier> Suppliers
		{
			get
			{
				if (supplierRepository == null)
					supplierRepository = new SupplierRepository(db);
				return supplierRepository;
			}
		}


		public void Save()
		{
			db.SaveChanges();
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
	}
}

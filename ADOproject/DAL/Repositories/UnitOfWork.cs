using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories;

namespace DAL
{
	public class UnitOfWork
	{
		private string connectionString;
		private ProductRepo productRepository;
		private CategoryRepo categoryRepository;
		private SupplierRepo supplierRepository;

		public UnitOfWork(string connectionString)
		{
			this.connectionString = connectionString;
		}
		public BaseRepo<Product> Products
		{
			get
			{
				if (productRepository == null)
					productRepository = new ProductRepo(connectionString);
				return productRepository;
			}
		}

		public BaseRepo<Category> Categories
		{
			get
			{
				if (categoryRepository == null)
					categoryRepository = new CategoryRepo(connectionString);
				return categoryRepository;
			}
		}

		public BaseRepo<Supplier> Suppliers
		{
			get
			{
				if (supplierRepository == null)
					supplierRepository = new SupplierRepo(connectionString);
				return supplierRepository;
			}
		}


	}
}

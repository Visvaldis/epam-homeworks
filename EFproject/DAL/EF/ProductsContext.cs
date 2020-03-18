using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
	public class ProductsContext : DbContext
	{
		public DbSet<Category> Categories { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<Product> Products { get; set; }

		static ProductsContext()
		{
			Database.SetInitializer<ProductsContext>(new StoreDbInitializer());
		}
		public ProductsContext(string connectionString)
			: base(connectionString)
		{
			


		}

	}

	public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<ProductsContext>
	{
		protected override void Seed(ProductsContext context)
		{
			var Phones = new Category { Name = "Phones" };
			var Laptops = new Category { Name = "Laptops" };
			var Tablets = new Category { Name = "Tablets" };
			context.Categories.Add(Phones);
			context.Categories.Add(Laptops);
			context.Categories.Add(Tablets);

			var Rozetka = new Supplier { Name = "Rozetka" };
			var Citrus = new Supplier { Name = "Citrus" };
			var Prom = new Supplier { Name = "Prom" };
			context.Suppliers.Add(Rozetka);
			context.Suppliers.Add(Citrus);
			context.Suppliers.Add(Prom);

			context.Products.Add(
				new Product { Name = "Xiaomi MI 10", Price = 500, Supplier = Rozetka, Category = Phones });
			context.Products.Add(
				new Product { Name = "Samsung S 11", Price = 900, Supplier = Rozetka, Category = Phones });
			context.Products.Add(
				new Product { Name = "Iphone 10", Price = 1000, Supplier = Citrus, Category = Phones });
			context.Products.Add(
				 new Product { Name = "Galaxy Tab S", Price = 800, Supplier = Prom, Category = Tablets });
			context.Products.Add(
				new Product { Name = "Ipad 3", Price = 700, Supplier = Prom, Category = Tablets });
			context.Products.Add(
				 new Product { Name = "Asus Rog", Price = 3000, Supplier = Rozetka, Category = Laptops });
			context.Products.Add(
				new Product { Name = "Asus Tuf Gaming", Price = 1500, Supplier = Prom, Category = Laptops });
			context.Products.Add(
				new Product { Name = "Xiaomi Gaming Laptop", Price = 1000, Supplier = Citrus, Category = Laptops });
			context.Products.Add(
				new Product { Name = "Acer Predator", Price = 2000, Supplier = Rozetka, Category = Laptops });
			context.Products.Add(
				new Product { Name = "Macbook Pro", Price = 3999, Supplier = Citrus, Category = Laptops });

			context.SaveChanges();
		}
	}

}

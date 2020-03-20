using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Models;
using DAL.Repositories;
using DAL;

namespace ADOproject
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			string connectionString = @"Data Source=THUNDERBIRD;Initial Catalog=homework5;Integrated Security=True";
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				DBService service = new DBService(connectionString);

				var prod = service.GetProduct(1);
				Console.WriteLine(prod.Name, prod.Price);
				Console.WriteLine("\n\n");
				var prods = service.GetProducts();
				foreach (var item in prods)
				{
					Console.WriteLine(item.Name, item.Price);
				}
				Console.WriteLine("\n\n");
				var cats = service.GetProductsFromCategory(5);
				foreach (var item in cats)
				{
					Console.WriteLine(item.Name, item.Price);
				}
				Console.WriteLine("\n\n");
				var sups = service.GetProductsFromSupplier(2);
				foreach (var item in sups)
				{
					Console.WriteLine(item.Name, item.Price);
				}
				Console.WriteLine("\n\n");

			}

			Console.WriteLine("Подключение закрыто...");

			Console.ReadKey();

		}

		static void FillDatabase(string connectionString)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				UnitOfWork database = new UnitOfWork(connectionString);

				var supCitrus = new Supplier() { Name = "Citrus" };
				var supProm = new Supplier() { Name = "Prom" };
				var supRoz = new Supplier() { Name = "Rozetka" };

				int indCitrus = database.Suppliers.Create(supCitrus);
				int indProm = database.Suppliers.Create(supProm);
				int indRoz = database.Suppliers.Create(supRoz);

				var catPhone = new Category() { Name = "Phone" };
				var catLaptop = new Category() { Name = "Laptop" };
				var catTabl = new Category() { Name = "Tablet" };

				int indPhone = database.Categories.Create(catPhone);
				int indLap = database.Categories.Create(catLaptop);
				int indTabl = database.Categories.Create(catTabl);

				database.Products.Create(new Product { Name = "Xiaomi Mi 10", Price = 1000, CategoryId = indPhone, SupplierId = indCitrus });
				database.Products.Create(new Product { Name = "Iphone", Price = 1500, CategoryId = indPhone, SupplierId = indRoz });
				database.Products.Create(new Product { Name = "Samsung S 9", Price = 1200, CategoryId = indPhone, SupplierId = indCitrus });
				database.Products.Create(new Product { Name = "Ipad", Price = 1300, CategoryId = indTabl, SupplierId = indRoz });
				database.Products.Create(new Product { Name = "Galaxy Tab 2", Price = 2000, CategoryId = indTabl, SupplierId = indCitrus });
				database.Products.Create(new Product { Name = "Tuf Gaming", Price = 1400, CategoryId = indLap, SupplierId = indProm });
				database.Products.Create(new Product { Name = "MSI GS 66", Price = 2500, CategoryId = indLap, SupplierId = indProm });
				database.Products.Create(new Product { Name = "Macbook pro", Price = 3000, CategoryId = indLap, SupplierId = indCitrus });

			}

		}
	}
}

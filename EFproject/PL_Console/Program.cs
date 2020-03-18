using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL_Console.Util;
using PL_Console.Models;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using BLL.Infrastructure;
using System.Web.Mvc;
using BLL.Interfaces;
using BLL.Services;

namespace PL_Console
{
	class Program
	{
		static IProductService productService;
		static void Main(string[] args)
		{
			productService = new ProductService("name = DefaultConnection");
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			Console.WriteLine("All products: ");
			var prod = productService.GetProducts();
			foreach (var item in prod)
			{
				Console.WriteLine($"{item.Name} \t\t\t{item.Price} \t\t{item.Category.Name} \t\t{item.Supplier.Name}");
			}

			Console.WriteLine("\n\nGet product with id = 1:");
			var item1 = productService.GetProduct(1);
			Console.WriteLine($"{item1.Name} \t{item1.Price} \t{item1.Category.Name} \t{item1.Supplier.Name}");

			Console.WriteLine("\n\nGet Products From Category with id = 1: ");
			var cat = productService.GetProductsFromCategory(1);
			foreach (var item in cat)
			{
				Console.WriteLine($"{item.Name} \t{item.Category.Name}");
			}

			Console.WriteLine("\n\nGet Products From Supplier with id = 1: ");
			var prodSup = productService.GetProductsFromSupplier(1);
			foreach (var item in prodSup)
			{
				Console.WriteLine($"{item.Name} \t{item.Supplier.Name}");
			}

			Console.WriteLine("\n\nGet Suppliers From Category with id = 1");
			var sup = productService.GetSuppliersFromCategory(1);
			foreach (var item in sup)
			{
				Console.WriteLine($"{item.Name}");
			}

			Console.WriteLine("\n\nAll products which price above 1000:");
			var prod1 = productService.FindProducts(p => p.Price > 1000);
			foreach (var item in prod1)
			{
				Console.WriteLine($"{item.Name} \t{item.Price}");
			}
			Console.ReadKey();
		}

	}
}

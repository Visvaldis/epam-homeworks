using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class DBService
	{
		private UnitOfWork db;
		private string connectionString;
		public DBService(string connectionString)
		{
			this.connectionString = connectionString;
			db = new UnitOfWork(connectionString);
		}
		public Product GetProduct(int id)
		{
			return db.Products.Get(id);
		}
		public IEnumerable<Product> GetProducts()
		{
			return db.Products.GetAll();
		}
		public IEnumerable<Product> GetProductsFromCategory(int categoryID)
		{
			string sqlExpression = $@"SELECT p.id, p.Name, p.CategoryID, p.SupplierID, p.Price
									FROM Products p JOIN Category c
									On p.CategoryID = c.id
									where c.id = {categoryID}";
			var prods = new List<Product>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand command = new SqlCommand(sqlExpression, connection);
				SqlDataReader reader = command.ExecuteReader();

				if (reader.HasRows) // если есть данные
				{
					// выводим названия столбцов
					while (reader.Read()) // построчно считываем данные
					{
						var prod = new Product()
						{
							Id = (int)reader.GetValue(0),
							Name = reader.GetValue(1).ToString(),
							CategoryId = (int)reader.GetValue(2),
							SupplierId = (int)reader.GetValue(3),
							Price = (double)reader.GetValue(4)
						};
						prods.Add(prod);
					}
				}

				reader.Close();
			}
			return prods;
		}
		public IEnumerable<Product> GetProductsFromSupplier(int supplierID)
		{
			string sqlExpression = $@"SELECT p.id, p.Name, p.CategoryID, p.SupplierID, p.Price
									FROM Products p JOIN Suppliers c
									On p.SupplierID = c.id
									where c.id = {supplierID}";
			var prods = new List<Product>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand command = new SqlCommand(sqlExpression, connection);
				SqlDataReader reader = command.ExecuteReader();

				if (reader.HasRows) 
				{
					while (reader.Read())
					{
						var prod = new Product()
						{
							Id = (int)reader.GetValue(0),
							Name = reader.GetValue(1).ToString(),
							CategoryId = (int)reader.GetValue(2),
							SupplierId = (int)reader.GetValue(3),
							Price = (double)reader.GetValue(4)
						};
						prods.Add(prod);
					}
				}

				reader.Close();
			}
			return prods;
		}
		public IEnumerable<Supplier> GetSuppliersFromCategory(int categoryID)
		{
			string sqlExpression = $@"SELECT s.id, s.Name
									FROM Products p JOIN Category c
									On p.CategoryID = c.id
									JOIN Suppliers s ON p.SupplierID = s.ID 
									where c.id = {categoryID}";
			var prods = new List<Supplier>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand command = new SqlCommand(sqlExpression, connection);
				SqlDataReader reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read()) 
					{
						var sup = new Supplier()
						{
							Id = (int)reader.GetValue(0),
							Name = reader.GetValue(1).ToString()
						};
						prods.Add(sup);
					}
				}

				reader.Close();
			}
			return prods;
		}
	}
}

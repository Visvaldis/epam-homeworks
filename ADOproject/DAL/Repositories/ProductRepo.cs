using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
	class ProductRepo : BaseRepo<Product>
	{
		public ProductRepo(string connectionString) : base(connectionString)
		{
		}

		public override int Create(Product item)
		{
			var parameters = new List<SqlParameter>();
			parameters.Add(sqlHelper.CreateParameter("@Name", 50, item.Name, DbType.String));
			parameters.Add(sqlHelper.CreateParameter("@CategoryID", 50, item.CategoryId, DbType.Int32));
			parameters.Add(sqlHelper.CreateParameter("@SupplierID", 50, item.SupplierId, DbType.Int32));
			parameters.Add(sqlHelper.CreateParameter("@Price", 50, item.Price, DbType.Double));
			int lastId = 0;
			sqlHelper.Insert("Products_Insert", CommandType.StoredProcedure, parameters.ToArray(), out lastId);

			return lastId;
		}

		public override void Delete(int id)
		{
			var parameters = new List<SqlParameter>();
			parameters.Add(sqlHelper.CreateParameter("@Id", id, DbType.Int32));

			sqlHelper.Delete("Products_Delete", CommandType.StoredProcedure, parameters.ToArray());


		}

		public override Product Get(int id)
		{
			var parameters = new List<SqlParameter>();
			parameters.Add(sqlHelper.CreateParameter("@Id", id, DbType.Int32));

			var dataReader = sqlHelper.GetDataReader("Products_GetById", CommandType.StoredProcedure, parameters.ToArray(), out connection);

			try
			{
				var prod = new Product();
				while (dataReader.Read())
				{
					prod.Name = dataReader["Name"].ToString();
					prod.CategoryId = (int)dataReader["CategoryID"];
					prod.SupplierId = (int)dataReader["SupplierID"];
					prod.Price = (double)dataReader["Price"];

				}

				return prod;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				dataReader.Close();
				CloseConnection();
			}
		}

		public override IEnumerable<Product> GetAll()
		{
			var parameters = new List<SqlParameter>();
			var dataReader = sqlHelper.GetDataReader("Products_GetAll", CommandType.StoredProcedure, null, out connection);

			try
			{
				var products = new List<Product>();
				while (dataReader.Read())
				{
					var prod = new Product();
					prod.Name = dataReader["Name"].ToString();
					prod.CategoryId = (int)dataReader["CategoryID"];
					prod.SupplierId = (int)dataReader["SupplierID"];
					prod.Price = (double)dataReader["Price"];


					products.Add(prod);
				}

				return products;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				dataReader.Close();
				CloseConnection();
			}
		}

		public override void Update(Product item)
		{
			var parameters = new List<SqlParameter>();
			parameters.Add(sqlHelper.CreateParameter("@Id", item.Id, DbType.Int32));
			parameters.Add(sqlHelper.CreateParameter("@Name", 50, item.Name, DbType.String));
			parameters.Add(sqlHelper.CreateParameter("@CategoryID", 50, item.Name, DbType.Int32));
			parameters.Add(sqlHelper.CreateParameter("@SupplierID", 50, item.Name, DbType.Int32));
			parameters.Add(sqlHelper.CreateParameter("@Price", 50, item.Name, DbType.Double));

			sqlHelper.Update("Products_Update", CommandType.StoredProcedure, parameters.ToArray());


		}
	}
}

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
	class SupplierRepo : BaseRepo<Supplier>
	{
		public SupplierRepo(string connectionString) : base(connectionString)
		{
		}

		public override int Create(Supplier item)
		{
			var parameters = new List<SqlParameter>();
			parameters.Add(sqlHelper.CreateParameter("@Name", 50, item.Name, DbType.String));
			int lastId = 0;
			sqlHelper.Insert("Suppliers_Insert", CommandType.StoredProcedure, parameters.ToArray(), out lastId);

			return lastId;
		}

		public override void Delete(int id)
		{
			var parameters = new List<SqlParameter>();
			parameters.Add(sqlHelper.CreateParameter("@Id", id, DbType.Int32));

			sqlHelper.Delete("Suppliers_Delete", CommandType.StoredProcedure, parameters.ToArray());

		}

		public override Supplier Get(int id)
		{
			var parameters = new List<SqlParameter>();
			parameters.Add(sqlHelper.CreateParameter("@Id", id, DbType.Int32));

			var dataReader = sqlHelper.GetDataReader("Suppliers_GetById", CommandType.StoredProcedure, parameters.ToArray(), out connection);

			try
			{
				var sup = new Supplier();
				while (dataReader.Read())
				{
					sup.Name = dataReader["Name"].ToString();
				}

				return sup;
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

		public override IEnumerable<Supplier> GetAll()
		{
			var parameters = new List<SqlParameter>();
			var dataReader = sqlHelper.GetDataReader("Suppliers_GetAll", CommandType.StoredProcedure, null, out connection);

			try
			{
				var suppliers = new List<Supplier>();
				while (dataReader.Read())
				{
					var sup = new Supplier();
					sup.Name = dataReader["Name"].ToString();

					suppliers.Add(sup);
				}

				return suppliers;
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

		public override void Update(Supplier item)
		{
			var parameters = new List<SqlParameter>();
			parameters.Add(sqlHelper.CreateParameter("@Id", item.Id, DbType.Int32));
			parameters.Add(sqlHelper.CreateParameter("@FirstName", 50, item.Name, DbType.String));

			sqlHelper.Update("Suppliers_Update", CommandType.StoredProcedure, parameters.ToArray());

		}
	}
}

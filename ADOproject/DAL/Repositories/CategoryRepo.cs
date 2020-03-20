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
	public class CategoryRepo : BaseRepo<Category>
	{
		public CategoryRepo(string connectionString) : base(connectionString)
		{
		}

		public override int Create(Category item)
		{
			var parameters = new List<SqlParameter>();
			parameters.Add(sqlHelper.CreateParameter("@Name", 50, item.Name, DbType.String));
			int lastId = 0;
			sqlHelper.Insert("Category_Insert", CommandType.StoredProcedure, parameters.ToArray(), out lastId);

			return lastId;
		}

		public override void Delete(int id)
		{
			var parameters = new List<SqlParameter>();
			parameters.Add(sqlHelper.CreateParameter("@Id", id, DbType.Int32));

			sqlHelper.Delete("Category_Delete", CommandType.StoredProcedure, parameters.ToArray());

		}

		public override Category Get(int id)
		{
			var parameters = new List<SqlParameter>();
			parameters.Add(sqlHelper.CreateParameter("@Id", id, DbType.Int32));

			var dataReader = sqlHelper.GetDataReader("Category_GetById", CommandType.StoredProcedure, parameters.ToArray(), out connection);

			try
			{
				var cat = new Category();
				while (dataReader.Read())
				{
					cat.Name = dataReader["Name"].ToString();
				}

				return cat;
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

		public override IEnumerable<Category> GetAll()
		{
			var parameters = new List<SqlParameter>();
			var dataReader = sqlHelper.GetDataReader("Category_GetAll", CommandType.StoredProcedure, null, out connection);

			try
			{
				var categories = new List<Category>();
				while (dataReader.Read())
				{
					var cat = new Category();
					cat.Name = dataReader["Name"].ToString();

					categories.Add(cat);
				}

				return categories;
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

		public override void Update(Category item)
		{
			var parameters = new List<SqlParameter>();
			parameters.Add(sqlHelper.CreateParameter("@Id", item.Id, DbType.Int32));
			parameters.Add(sqlHelper.CreateParameter("@Name", 50, item.Name, DbType.String));

			sqlHelper.Update("Category_Update", CommandType.StoredProcedure, parameters.ToArray());

		}
	}
}

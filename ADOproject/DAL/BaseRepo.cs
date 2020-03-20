using System.Data.SqlClient;
using DAL.Util;
using System.Configuration;
using System.Collections.Generic;
namespace DAL
{
	public abstract class BaseRepo<T>
	{
		public SqlHelper sqlHelper = null;
		public SqlConnection connection = null;

		public BaseRepo(string connectionString)
		{
			sqlHelper = new SqlHelper(connectionString);
		}

		public void CloseConnection()
		{
			sqlHelper.CloseConnection(connection);
		}
		abstract public int Create(T item);
		abstract public T Get(int id);
		abstract public IEnumerable<T> GetAll();
		abstract public void Update(T item);
		abstract public void Delete(int id);

	}
}

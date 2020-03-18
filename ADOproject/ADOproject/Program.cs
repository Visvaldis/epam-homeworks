using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADOproject
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			string connectionString = @"Data Source=THUNDERBIRD;Initial Catalog=homework4;Integrated Security=True";
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				Console.WriteLine("Подключение открыто");

				// Вывод информации о подключении
				Console.WriteLine("Свойства подключения:");
				Console.WriteLine("\tСтрока подключения: {0}", connection.ConnectionString);
				Console.WriteLine("\tБаза данных: {0}", connection.Database);
				Console.WriteLine("\tСервер: {0}", connection.DataSource);
				Console.WriteLine("\tВерсия сервера: {0}", connection.ServerVersion);
				Console.WriteLine("\tСостояние: {0}", connection.State);
				Console.WriteLine("\tWorkstationld: {0}", connection.WorkstationId);
			}

			Console.WriteLine("Подключение закрыто...");

			Console.ReadKey();

		}
	}
}

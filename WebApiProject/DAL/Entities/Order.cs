using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<Product> Products  { get; set; }

		public Order()
		{
			Products = new List<Product>();
		}
	}
}

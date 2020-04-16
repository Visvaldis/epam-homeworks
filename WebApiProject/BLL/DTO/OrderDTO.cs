using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
	public class OrderDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<ProductDTO> Products  { get; set; }

		public OrderDTO()
		{
			Products = new List<ProductDTO>();
		}
	}
}

using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	interface IOrderService : IService<OrderDTO>
	{
		IEnumerable<ProductDTO> GetAllProductsByOrder(int id);
		void AddProductToOrder(int orderId, int productId);
	}
}

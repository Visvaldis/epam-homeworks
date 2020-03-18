using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
	public interface IProductService
	{
		ProductDTO GetProduct(int id);
		IEnumerable<ProductDTO> GetProducts();
		IEnumerable<ProductDTO> GetProductsFromCategory(int categoryID);
		IEnumerable<ProductDTO> GetProductsFromSupplier(int supplierID);
		IEnumerable<SupplierDTO> GetSuppliersFromCategory(int categoryID);
		IEnumerable<ProductDTO> FindProducts(Expression<Func<ProductDTO, bool>> predicate);
		void Dispose();
	}
}

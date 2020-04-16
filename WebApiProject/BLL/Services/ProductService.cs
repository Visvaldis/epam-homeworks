using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class ProductService : IProductService
	{
		IUnitOfWork Database { get; set; }
		IMapper Mapper { get; set; }

		public ProductService(IUnitOfWork uow)
		{
			Database = uow;
			Mapper = new MapperConfiguration(cfg => {
				cfg.CreateMap<Product, ProductDTO>();
				cfg.CreateMap<ProductDTO, Product>();
			})
			.CreateMapper();
		}

		public int Add(ProductDTO item)
		{
			if (item == null)
				throw new ArgumentNullException("Current product is null. Try again.");

			var product = Database.Orders.Find(x => x.Name.ToLower() == item.Name.ToLower());
			if (product.ToList().Count == 0)
			{
				var id = Database.Products.Create(Mapper.Map<ProductDTO, Product>(item));
				Database.Save();
				return id;
			}
			return 0;
		}

		public void Delete(int id)
		{
			Database.Products.Delete(id);
			Database.Save();
		}

		public void Dispose()
		{
			Database.Dispose();
		}

		public ProductDTO Get(int id)
		{
			var product = Database.Products.Get(id);
			if (product == null)
				throw new ValidationException("Current product is not found");

			return Mapper.Map<Product, ProductDTO>(product);
		}

		public IEnumerable<ProductDTO> GetAll()
		{
			return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
		}

		public IEnumerable<ProductDTO> GetWithFilter(Func<ProductDTO, bool> filter)
		{

			var mapper = new MapperConfiguration(
			cfg => cfg.CreateMap<Func<ProductDTO, bool>,
			Expression<Func<Product, bool>>>())
				.CreateMapper();

			var expression = mapper.Map<Expression<Func<Product, bool>>>(filter);


			return Mapper.Map<IEnumerable<Product>, List<ProductDTO>>
				(Database.Products.Find(expression).ToList());
		}

		public void Update(ProductDTO item)
		{
			Database.Products.Update(Mapper.Map<ProductDTO, Product>(item));
			Database.Save();
		}
	}
}

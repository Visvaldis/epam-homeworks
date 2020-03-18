using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Interfaces;
using System.Threading.Tasks;
using BLL.DTO;
using System.Linq.Expressions;
using DAL.Repositories;
using DAL.Interfaces;
using DAL.Entities;
using BLL.Infrastructure;
using AutoMapper;

namespace BLL.Services
{
	public class ProductService : IProductService
	{
		IUnitOfWork Database { get; set; }
		IMapper mapperProduct { get; set; }

		IMapper mapperSupplier { get; set; }

		IMapper mapperCategory { get; set; }


		public ProductService(string connectionString)
		{
			Database = new EFUnitOfWork(connectionString);

			var configuration = new MapperConfiguration(cfg =>
			{
				/*
								cfg.CreateMap<Product, ProductDTO>()
							 .ForMember(pr => pr.CategoryID, conf => conf.MapFrom(pr => pr.Category.Id))
							 .ForMember(pr => pr.SupplierID, conf => conf.MapFrom(pr => pr.Supplier.Id));
				*/
				cfg.CreateMap<Product, ProductDTO>()
				 .ForMember(pr => pr.Category, conf => conf.MapFrom(pr => pr.Category))
				 .ForMember(pr => pr.Supplier, conf => conf.MapFrom(pr => pr.Supplier));
				cfg.CreateMap<Category, CategoryDTO>();
				cfg.CreateMap<Supplier, SupplierDTO>();
			});


			mapperProduct = configuration
				.CreateMapper();
			mapperSupplier = new MapperConfiguration(cfg => cfg.CreateMap<Supplier, SupplierDTO>())
				.CreateMapper();
			mapperCategory = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>())
				.CreateMapper();
		}
		

		public IEnumerable<ProductDTO> FindProducts(
			Expression<Func<ProductDTO, bool>> predicate)
		{

			var mapper = new MapperConfiguration(
				cfg => cfg.CreateMap<Expression<Func<ProductDTO, bool>>, 
				Expression<Func<Product, bool>>>())
					.CreateMapper();

			var expression = mapper.Map<Expression<Func<Product, bool>>>(predicate);


			return mapperProduct.Map<IEnumerable<Product>, List<ProductDTO>>
				(Database.Products.Find(expression).ToList()); 
		}


		public ProductDTO GetProduct(int id)
		{
			var product = Database.Products.Get(id);
			if (product == null)
				throw new ValidationException("Current phone is not found");

			return mapperProduct.Map<Product, ProductDTO>(product);
		}

		public IEnumerable<ProductDTO> GetProducts()
		{
			return mapperProduct.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
		}

		public IEnumerable<SupplierDTO> GetSuppliersFromCategory(int categoryID)
		{

			var category = Database.Categories.Get(categoryID);
			if (category == null)
				throw new ValidationException("Current category is not found");

			var suppliers =
				(from prod in Database.Products.GetAll()
				where prod.Category.Id == categoryID
				select prod.Supplier).Distinct();

			return mapperSupplier.Map<IEnumerable<Supplier>, List<SupplierDTO>>(suppliers);
		}


		public IEnumerable<ProductDTO> GetProductsFromCategory(int categoryID)
		{

			var category = Database.Categories.Get(categoryID);
			if (category == null)
				throw new ValidationException("Current category is not found");

			var products =
				from prod in Database.Products.GetAll()
				where prod.Category.Id == categoryID
				select prod;

			return mapperProduct.Map<IEnumerable<Product>, List<ProductDTO>>(products);
		}

		public IEnumerable<ProductDTO> GetProductsFromSupplier(int supplierID)
		{
			var supplier = Database.Suppliers.Get(supplierID);
			if (supplier == null)
				throw new ValidationException("Current supplier is not found");

			var products =
				from prod in Database.Products.GetAll()
				where prod.Supplier.Id == supplierID
				select prod;

			return mapperProduct.Map<IEnumerable<Product>, List<ProductDTO>>(products);
		}

		public void Dispose()
		{
			Database.Dispose();
		}
	}
}

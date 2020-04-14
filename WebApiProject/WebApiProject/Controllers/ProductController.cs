using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebApiProject.Controllers
{
    public class ProductController : ApiController
    {
		private readonly IProductService productService;
		public ProductController(IProductService service)
		{
			productService = service;
		}

		[HttpGet]
		public IHttpActionResult Get(int id)
		{
			var prod = productService.Get(id);
			try
			{
				return Ok(prod);
			}
			catch (ValidationException ex)
			{
				return NotFound();
			}
		}
		[HttpGet]
		public IHttpActionResult Get()
		{
			var prods = productService.GetAll();
			return Ok(prods);
		}
		
		[HttpPost]
		public IHttpActionResult Add([FromBody] ProductDTO prod)
		{
			productService.Add(prod);
			return Ok();
		}
		[HttpPut]
		public IHttpActionResult Update([FromBody] ProductDTO prod)
		{
			productService.Update(prod);
			return Ok();
		}

		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			productService.Delete(id);
			return Ok();
		}
	}
}

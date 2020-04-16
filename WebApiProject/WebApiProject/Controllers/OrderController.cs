using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiProject.Controllers
{
	
	public class OrderController : ApiController
	{
		private readonly IOrderService orderService;
		private readonly IProductService productService;
		public OrderController(IOrderService OrdService, IProductService ProdService)    
		{
			orderService = OrdService;
			productService = ProdService;
		}

		[HttpGet]
		public IHttpActionResult Get(int id)
		{
			try
			{
				var order = orderService.Get(id);
				return Ok(order);
			}
			catch (Exception ex)
			{
				return NotFound();
			}
		}
		[HttpGet]
		public IHttpActionResult Get()
		{
			var prods = orderService.GetAll();
			return Ok(prods);
		}

		[HttpPost]
		public IHttpActionResult Add([FromBody] OrderDTO order)
		{
			if (!ModelState.IsValid) return BadRequest();

			orderService.Add(order);
			return Ok();
		}
		[HttpPut]
		public IHttpActionResult Update([FromBody]  OrderDTO order)
		{
			orderService.Update(order);
			return Ok();
		}

		[HttpDelete]
		public IHttpActionResult Delete(int id)
		{
			orderService.Delete(id);
			return Ok();
		}

		[HttpPost]
		[Route("api/Order/{order_id}/Product/{product_id}")]
		public IHttpActionResult AddProductToOrder(int order_id, int product_id)
		{

			orderService.AddProductToOrder(order_id, product_id);
			return Ok();
		}
		[HttpPost]
		[Route("api/Order/{order_id}/Product/")]
		public IHttpActionResult AddProductToOrder(int order_id, [FromBody] ProductDTO prod)
		{
			int product_id = productService.Add(prod);
			if (product_id == 0) return BadRequest();
			orderService.AddProductToOrder(order_id, product_id);
			return Ok();
		}
		
		[HttpGet]
		[Route("Order/{order_id}/Product/")]
		public IHttpActionResult GetAllProductsByOrder(int order_id)
		{
			var prods = orderService.GetAllProductsByOrder(order_id);
			return Ok(prods);
		}


	}
	
}

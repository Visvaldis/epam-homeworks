﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
	public class ProductDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
	
		 	public CategoryDTO Category { get; set; }
		public SupplierDTO Supplier { get; set; }
		

	}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<Category> Categories { get; }
		IRepository<Supplier> Suppliers { get; }
		IRepository<Product> Products { get; }
		void Save();
	}
}

using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Context
{
	class OrderContext :DbContext
	{
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }

		public OrderContext(string connectionString)
				: base(connectionString)
		{ }
		public OrderContext() : base("WebApiContext")
		{ }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Product>()
				.HasMany(p => p.Orders)
				.WithMany(c => c.Products)
				.Map(m =>
				{
					m.ToTable("OrderProduct");

				});
			base.OnModelCreating(modelBuilder);

		}
	}
}

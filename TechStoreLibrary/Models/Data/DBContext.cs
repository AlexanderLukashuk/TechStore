using System;
using Microsoft.EntityFrameworkCore;
using TechStoreLibrary.Models.Entities;

namespace TechStoreLibrary.Models.Data
{
	public class DBContext : DbContext
	{
		public DBContext(DbContextOptions<DBContext> options)
			: base(options)
		{
		}

		public DbSet<Product> Products { get; set; }

		public DbSet<Category> Categories { get; set; }
	}
}


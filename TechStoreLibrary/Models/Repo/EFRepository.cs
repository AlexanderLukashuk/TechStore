using System;
using TechStoreLibrary.Models.Entities;

namespace TechStoreLibrary.Models.Repo
{
	public class EFRepository : IRepository
	{
		private DBContext context;

		public EFRepository(DBContext ctx)
		{
			context = ctx;
		}

		public IQueryable<Product> Products => context.Products;

		public IQueryable<Category> Categories => context.Categories;
    }
}


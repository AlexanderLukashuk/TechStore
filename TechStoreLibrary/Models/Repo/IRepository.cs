using System;
using TechStoreLibrary.Models.Entities;

namespace TechStoreLibrary.Models.Repo
{
	public interface IRepository
	{
		IQueryable<Product> Products { get; }
		IQueryable<Category> Categories { get; }
	}
}


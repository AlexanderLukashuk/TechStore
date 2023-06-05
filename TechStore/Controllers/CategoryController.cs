using System;
using Microsoft.AspNetCore.Mvc;
using TechStoreLibrary.Models.Data;
using TechStoreLibrary.Models.Repo;

namespace TechStore.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IRepository _repository;

		private DBContext _dBContext;

		public CategoryController(IRepository repository, DBContext context)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
			_dBContext = context;
		}

		//[Route("/Category")]
		public IActionResult Index() => View(_repository.Categories);

		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var category = _dBContext.Categories.FirstOrDefault(c => c.Id == id);
			if (category == null)
			{
				return NotFound();
			}

			var products = _dBContext.Products.Where(p => p.CategoryId == category.Id).ToList();
			ViewData["Products"] = products;

			return View(category);
		}
	}
}


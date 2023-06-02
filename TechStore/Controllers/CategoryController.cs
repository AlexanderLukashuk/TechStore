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

		[Route("/Categories")]
		public IActionResult Index() => View(_repository.Categories);
	}
}


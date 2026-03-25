using System.Diagnostics;
using LorasApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LorasApp.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			HttpContext.Session.Clear();
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

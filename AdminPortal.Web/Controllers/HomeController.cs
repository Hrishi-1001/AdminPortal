using AdminPortal.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPortal.Web.Controllers
{
	public class HomeController : Controller
	{
		[Route("/Home")]
		public IActionResult Index(Map map)
		{
			return View(map);
		}
	}
}

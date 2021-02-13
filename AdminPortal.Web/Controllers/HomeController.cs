using AdminPortal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

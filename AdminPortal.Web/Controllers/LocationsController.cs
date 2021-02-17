using AdminPortal.Web.Data;
using AdminPortal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Web.Controllers
{
	public class LocationsController : Controller
	{
		private readonly DatabaseContext databaseContext;

		public LocationsController(Data.DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		[Route("/Locations/Add")]
		public IActionResult Add()
		{
			return View();
		}

		// POST: LocationsController/Create
		[HttpPost]
		[Route("/Locations/Add")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id", "Name")] Location location)
		{
			if (ModelState.IsValid && !databaseContext.Locations.Where(o => o.Id.Equals(location.Id)).Any())
			{
				databaseContext.Locations.Add(location);
				await databaseContext.SaveChangesAsync();
				return RedirectToAction("Create", "Assets");
			}
			return RedirectToAction("Create", "Assets");
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminPortal.Web.Data;
using AdminPortal.Web.Models;

namespace AdminPortal.Web.Controllers
{
	public class LocationsController : Controller
	{
		private readonly DatabaseContext _context;

		public LocationsController(DatabaseContext context)
		{
			_context = context;
		}

		[Route("/Locations/Add")]
		public IActionResult Add()
		{
			return View();
		}

		// POST: Locations/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[Route("/Locations/Add")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Add([Bind("Id,Name,Latitude,Longitude")] Location location)
		{
			if (ModelState.IsValid)
			{
				_context.Add(location);
				await _context.SaveChangesAsync();
				return RedirectToAction("Create", "Assets", new
				{ 
					selectedLocation = location.Name 
				});
			}
			return View(location);
		}

	}
}

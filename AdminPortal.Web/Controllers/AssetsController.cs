using AdminPortal.Web.Data;
using AdminPortal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Web.Controllers
{
	public class AssetsController : Controller
	{
		private readonly DatabaseContext databaseContext;

		public AssetsController(Data.DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		[Route("/Assets")]
		public async Task<IActionResult> Index(string searchString)
		{
			IQueryable<Asset> list = databaseContext.Assets.Include(o => o.Location).Include(o => o.Alerts);
			if (!string.IsNullOrEmpty(searchString))
			{
				list = list.Where(asset => asset.Id.ToString().Contains(searchString));
			}
			return View(await list.ToListAsync());
		}																						

		[Route("/Assets/create")]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[Route("/Assets/Create")]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Create([Bind("LocationId", "Latitude", "Longitude")] Asset asset)
		{
			if (ModelState.IsValid)
			{
				asset.Alerts = new List<Alert>
				{
					new Alert
					{
						Text = "Asset Created",
						AssetID = asset.Id
					}
				};
				asset.State = AssetState.functional;
				asset.LastServiced = DateTime.Now;
				databaseContext.Assets.Add(asset);
				await databaseContext.SaveChangesAsync();
				return RedirectToAction("Index", "Assets");
			}
			return View(asset);
		}

		[Route("/Assets/Delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (ModelState.IsValid)
			{
				Asset purgeAsset =  await databaseContext.Assets.Where(asset => asset.Id.Equals(id)).
					FirstOrDefaultAsync();
				purgeAsset.State = AssetState.deleted;
				databaseContext.Alerts.Add(new Alert
				{
					AssetID = purgeAsset.Id,
					Text = "Asset Deleted",
				});
				await databaseContext.SaveChangesAsync();
			}
			return RedirectToAction("Index");
		}
	}
}

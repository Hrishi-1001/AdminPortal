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
	public class AlertsController : Controller
	{
		private readonly DatabaseContext databaseContext;

		public AlertsController(Data.DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		[Route("/Alerts")]
		[Route("/Alerts/{id}")]
		public async Task<IActionResult> Index(string id = null)
		{
			IQueryable<Alert> list = databaseContext.Alerts.Include(o => o.Asset).Include(o => o.Asset.Location);
			if (!string.IsNullOrEmpty(id))
			{
				list = list.Where(o => o.AssetID.ToString().Contains(id));
			}
			return View(await list.ToListAsync());
		}

		[HttpPost]
		[Route("/Alerts/Delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (ModelState.IsValid)
			{
				Alert identifiedAlert = await (from alerts in databaseContext.Alerts
											   where alerts.ID.Equals(id)
											   select alerts).FirstOrDefaultAsync();
				databaseContext.Alerts.Remove(identifiedAlert);
				await databaseContext.SaveChangesAsync();
				return RedirectToAction("Index", "Assets");
			}
			return RedirectToPage("/Error");
		}
	}
}

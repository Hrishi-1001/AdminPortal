using AdminPortal.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Web.Controllers
{
	public class ServicingController : Controller
	{
		private readonly DatabaseContext databaseContext;

		[Route("/Servicing/{assetId?}")]
		public async Task<IActionResult> Index(int assetId)
		{
			Models.Asset asset = await databaseContext.Assets.Include(o => o.Alerts).Where(o => o.Id == assetId).FirstOrDefaultAsync();
			return View(asset);
		}

		public ServicingController(Data.DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}
	}
}

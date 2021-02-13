using AdminPortal.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

		[Route("/Assets/Index")]
		[Route("/Assets/Index/{searchString?}")]
		public async Task<IActionResult> Index(string searchString)
		{
			var list = from assets in databaseContext.Assets
						select assets;
			if (!string.IsNullOrEmpty(searchString))
			{
				list = list.Where(asset => asset.Id.ToString().Contains(searchString));
			}
			return View(await list.ToListAsync());
		}
	}
}

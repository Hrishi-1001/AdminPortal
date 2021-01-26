using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPortal.Web.Data;
using AdminPortal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AdminPortal.Web.Pages.Assets
{
    public class IndexModel : PageModel
    {
		private readonly AssetDbContext assetDbContext;

		public IndexModel(AssetDbContext assetDbContext)
		{
			this.assetDbContext = assetDbContext;
		}

		public IList<Asset> Assets { get; set; }

		public async Task OnGetAsync()
        {
			Assets = await assetDbContext.Assets.ToListAsync();
        }
    }
}

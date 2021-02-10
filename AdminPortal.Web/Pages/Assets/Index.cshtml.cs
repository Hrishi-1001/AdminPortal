using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdminPortal.Web.Data;
using AdminPortal.Web.Models;

namespace AdminPortal.Web.Pages.Assets
{
    public class IndexModel : PageModel
    {
        private readonly AdminPortal.Web.Data.DatabaseContext _context;

        public IndexModel(AdminPortal.Web.Data.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
		public string SearchString { get; set; }

		public IList<Asset> Assets { get;set; }

        public async Task OnGetAsync(int? SearchString)
        {
            if (SearchString == null)
			{
                Assets = await _context.Assets.ToListAsync();
			}
            else
			{
                Assets = (from assets in _context.Assets.ToList()
                         where assets.AssetID == SearchString
                         select assets).ToList();

            }
        }
    }
}

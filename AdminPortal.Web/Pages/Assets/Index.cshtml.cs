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
        private readonly AdminPortal.Web.Data.AssetDbContext _context;

        public IndexModel(AdminPortal.Web.Data.AssetDbContext context)
        {
            _context = context;
        }

        public IList<Asset> Asset { get;set; }

        public async Task OnGetAsync()
        {
            Asset = await _context.Assets.ToListAsync();
        }
    }
}

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
    public class DetailsModel : PageModel
    {
        private readonly AdminPortal.Web.Data.AssetDbContext _context;

        public DetailsModel(AdminPortal.Web.Data.AssetDbContext context)
        {
            _context = context;
        }

        public Asset Asset { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Asset = await _context.Assets.FirstOrDefaultAsync(m => m.ID == id);

            if (Asset == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

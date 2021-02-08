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
    public class DeleteModel : PageModel
    {
        private readonly AdminPortal.Web.Data.DatabaseContext _context;

        public DeleteModel(AdminPortal.Web.Data.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Asset Asset { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Asset = await _context.Assets.FirstOrDefaultAsync(m => m.AssetID == id);

            if (Asset == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Asset = await _context.Assets.FindAsync(id);

            if (Asset != null)
            {
                _context.Assets.Remove(Asset);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

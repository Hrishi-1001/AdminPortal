using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminPortal.Web.Data;
using AdminPortal.Web.Models;

namespace AdminPortal.Web.Pages.Assets
{
    public class EditModel : PageModel
    {
        private readonly AdminPortal.Web.Data.AssetDbContext _context;

        public EditModel(AdminPortal.Web.Data.AssetDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Asset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(Asset.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AssetExists(string id)
        {
            return _context.Assets.Any(e => e.ID == id);
        }
    }
}

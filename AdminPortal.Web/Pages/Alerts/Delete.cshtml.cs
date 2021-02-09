using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdminPortal.Web.Data;
using AdminPortal.Web.Models;

namespace AdminPortal.Web.Pages.Alerts
{
    public class DeleteModel : PageModel
    {
        private readonly AdminPortal.Web.Data.DatabaseContext _context;

        public DeleteModel(AdminPortal.Web.Data.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Alert Alert { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Alert = await _context.Alerts.FirstOrDefaultAsync(m => m.AlertID == id);

            if (Alert == null)
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

            Alert = await _context.Alerts.FindAsync(id);

            if (Alert != null)
            {
                _context.Alerts.Remove(Alert);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

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
    public class DetailsModel : PageModel
    {
        private readonly AdminPortal.Web.Data.DatabaseContext _context;

        public DetailsModel(AdminPortal.Web.Data.DatabaseContext context)
        {
            _context = context;
        }

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
    }
}

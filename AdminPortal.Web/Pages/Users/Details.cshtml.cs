using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdminPortal.Data;
using AdminPortal.Repository;

namespace AdminPortal.Web.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly AdminPortal.Repository.AdminPortalDbContext _context;

        public DetailsModel(AdminPortal.Repository.AdminPortalDbContext context)
        {
            _context = context;
        }

        public new User User { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FirstOrDefaultAsync(m => m.PhoneNumber == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

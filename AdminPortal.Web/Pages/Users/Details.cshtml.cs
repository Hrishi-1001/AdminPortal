using AdminPortal.Models;
using AdminPortal.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AdminPortal.Web.Pages.Users
{
	[Authorize]
	public class DetailsModel : PageModel
    {
        private readonly AdminPortalDbContext _context;

        public DetailsModel(AdminPortalDbContext context)
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

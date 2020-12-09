using AdminPortal.Data;
using AdminPortal.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminPortal.Web.Pages.Users
{
	[Authorize]
	public class IndexModel : PageModel
    {
        private readonly AdminPortalDbContext _context;

        public IndexModel(AdminPortalDbContext context)
        {
            _context = context;
        }

        public new IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.Users.ToListAsync();
        }
    }
}

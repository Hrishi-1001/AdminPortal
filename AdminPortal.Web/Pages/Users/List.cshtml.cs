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
    public class IndexModel : PageModel
    {
        private readonly AdminPortal.Repository.AdminPortalDbContext _context;

        public IndexModel(AdminPortal.Repository.AdminPortalDbContext context)
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

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
        private readonly AdminPortal.Web.Data.DatabaseContext _context;

        public IndexModel(AdminPortal.Web.Data.DatabaseContext context)
        {
            _context = context;
        }

        public IList<Asset> Assets { get;set; }

        public async Task OnGetAsync()
        {
            Assets = await _context.Assets.ToListAsync();
        }
    }
}

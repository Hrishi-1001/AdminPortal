using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AdminPortal.Web.Data;
using AdminPortal.Web.Models;

namespace AdminPortal.Web.Pages.Alerts  
{
    public class CreateModel : PageModel
    {
        private readonly AdminPortal.Web.Data.DatabaseContext _context;

        public CreateModel(AdminPortal.Web.Data.DatabaseContext context)
        {
            _context = context;
        }

		public static int ID { get; set; }

		public IActionResult OnGet(int id)
        {
            ID = id;
            return Page();
        }

        [BindProperty]
        public Alert Alert { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Alert.AssetID = ID;

            _context.Alerts.Add(Alert);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

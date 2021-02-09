﻿using System;
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

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Alert Alert { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Alert.AssetID = id;

            _context.Alerts.Add(Alert);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

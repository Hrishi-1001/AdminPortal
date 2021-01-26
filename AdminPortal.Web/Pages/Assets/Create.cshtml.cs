using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AdminPortal.Web.Data;
using AdminPortal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPortal.Web.Pages.Assets
{
    public class CreateModel : PageModel
    {
		private readonly AssetDbContext assetDbContext;
		
		[BindProperty]
		public Asset Asset { get; set; }

		public CreateModel(AssetDbContext assetDbContext, Asset asset)
		{
			this.assetDbContext = assetDbContext;
			Asset = asset;
		}


		public IActionResult OnGet()
        {
			return Page();
        }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			assetDbContext.Assets.Add(Asset);
			await assetDbContext.SaveChangesAsync();
			return RedirectToPage("./Index");
		}
    }
}

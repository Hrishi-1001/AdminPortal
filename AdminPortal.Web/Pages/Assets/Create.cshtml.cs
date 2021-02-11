using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AdminPortal.Web.Data;
using AdminPortal.Web.Models;

namespace AdminPortal.Web.Pages.Assets
{
	public class CreateModel : PageModel
	{
		private readonly AdminPortal.Web.Data.DatabaseContext _context;
		public Location Location { get; set; }
		public IList<SelectListItem> Locations { get; set; }

		public CreateModel(AdminPortal.Web.Data.DatabaseContext context)
		{
			_context = context;
		}

		public IActionResult OnGet()
		{
			Locations = new List<SelectListItem>();
			foreach (var location in _context.Locations)
			{
				Locations.Add(new SelectListItem { 
					Value = location.ZIP,
					Text = location.Name,
				});
			}
			return Page();
		}

		[BindProperty]
		public Asset Asset { get; set; }

		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			Asset.Area = Location.Name;
			Asset.State = AssetState.functional;
			Asset.Moisture = 0.2m;
			Asset.Temperature = 26.4m;

			Alert alert = new Alert();
			alert.Text = "New Asset Added";
			_context.Assets.Add(Asset);
			await _context.SaveChangesAsync();

			alert.AssetID = Asset.AssetID;
			_context.Alerts.Add(alert);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}

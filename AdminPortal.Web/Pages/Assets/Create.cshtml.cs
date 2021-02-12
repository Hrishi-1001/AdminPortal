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
		public List<SelectListItem> Locations { get; }

		public CreateModel(DatabaseContext context, List<SelectListItem> items)
		{
			_context = context;
			Locations = items;
		}

		public IActionResult OnGet()
		{
			foreach (var location in _context.Locations)
			{
				Locations.Add(new SelectListItem 
				{ 
					Value = location.ZIP,
					Text = location.Name,
				});
			}
			return Page();
		}

		public IActionResult OnGetLocation(string zip)
		{
			foreach (var location in _context.Locations)
			{
				Locations.Add(new SelectListItem
				{
					Value = location.ZIP,
					Text = location.Name,
					Selected = (location.ZIP == zip ? true : false),
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
			await AssignValues();
			return RedirectToPage("./Index");
		}

		private async Task AssignValues()
		{
			foreach (var location in _context.Locations)
			{
				Locations.Add(new SelectListItem
				{
					Value = location.ZIP,
					Text = location.Name,
				});
			}
			Asset.Area = (from location in Locations
							where location.Value.Equals(Asset.Area)
							select location.Text).First();
			Asset.State = AssetState.functional;
			Asset.Moisture = 0.2m;
			Asset.Temperature = 26.4m;

			Alert alert = new Alert();
			alert.Text = "New Asset Added";
			alert.AssetID = Asset.AssetID;
			_context.Assets.Add(Asset);
			await _context.SaveChangesAsync();

			_context.Alerts.Add(alert);
			await _context.SaveChangesAsync();

			
		}
	}
}

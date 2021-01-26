using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminPortal.Web.Pages.Partials
{
	public class SelectLocModel : PageModel
	{
		public string Location { get; set; }

		public List<SelectListItem> Locations { get; } = new List<SelectListItem>
		{
			new SelectListItem { Value = 0.ToString(), Text = "Select Location" },
			new SelectListItem { Value = 411038.ToString(), Text = "Kothrud" },
			new SelectListItem { Value = 411043.ToString(), Text = "Dhanakawadi" },
			new SelectListItem { Value = 411052.ToString(), Text = "Karvenagar" },
			new SelectListItem { Value = 411057.ToString(), Text = "Wakad" },
		};

		public void OnGet()
		{

		}
	}
}

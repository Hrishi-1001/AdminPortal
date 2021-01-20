using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPortal.Web.Pages
{
	public class HomeModel : PageModel
	{
		[BindProperty(SupportsGet = true)]
		public string SearchString { get; set; }

		public void OnGet()
		{

		}
	}
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPortal.Web.Pages
{
	[Authorize]
	public class HomeModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}

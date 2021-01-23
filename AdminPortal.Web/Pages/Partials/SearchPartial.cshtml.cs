using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPortal.Web.Pages.Partials
{
    public class SearchPartialModel : PageModel
    {
        [BindProperty]
		public string ID { get; set; }

		public void OnGet()
        {
        }
    }
}

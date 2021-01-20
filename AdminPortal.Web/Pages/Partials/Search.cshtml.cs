using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPortal.Web.Pages.Partials
{
    public class SearchModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
		public string SearchString { get; set; }
                
		public void OnGet()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPortal.Web.Pages.Assets
{
    public class MapModel : PageModel
    {
        [BindProperty]
		public string PostalCode { get; set; }

        public void OnGet(string id)
		{
            PostalCode = id;
		}

    }
}

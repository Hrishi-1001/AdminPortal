using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPortal.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPortal.Web.Pages
{
    public class IndexModel : PageModel
    {

		public double DefaultLatitude { get; set; }
		public double DefaultLongitude { get; set; }
		public int DefaultZoom { get; set; }

		public IndexModel()
		{
			DefaultLatitude = 28.644800;
			DefaultLongitude = 77.216721;
			DefaultZoom = 8;
		}

		public void OnGet()
        {
        }
    }
}

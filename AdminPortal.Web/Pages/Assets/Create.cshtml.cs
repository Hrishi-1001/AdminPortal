using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdminPortal.Web.Models;

namespace AdminPortal.Web.Pages.Assets
{
	public class CreateModel : PageModel
	{
		private readonly AdminPortal.Web.Data.AssetDbContext _context;

		public CreateModel(AdminPortal.Web.Data.AssetDbContext context)
		{
			_context = context;
		}

		public IActionResult OnGet()
		{
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

			_context.Assets.Add(Asset);
			await _context.SaveChangesAsync();

			return RedirectToPage("/Map", new { id = Asset.ZIP });
		}
	}
}

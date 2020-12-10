using AdminPortal.Data;
using AdminPortal.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace AdminPortal.Web.Pages.Users
{
	// [Authorize]
	public class IndexModel : PageModel
    {
        private readonly AdminPortalDbContext _context;

        [DataType(DataType.PhoneNumber)]
		public string PhoneNumber { get; set; }


		public IndexModel(AdminPortalDbContext context)
        {
            _context = context;
        }

        public new IList<User> User { get;set; }

        public async Task OnGetAsync(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                User = await _context.Users.ToListAsync();
            }
            else
			{
                var _user = from user in await _context.Users.ToListAsync()
                            where user.PhoneNumber.Contains(PhoneNumber)
                            select user;
                User = _user.ToList();
			}
        }
    }
}

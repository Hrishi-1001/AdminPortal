using Microsoft.AspNetCore.Identity;

namespace AdminPortal.Web.Models
{
	public class Role : IdentityRole
	{
		public bool Admin { get; set; }
		public bool ServiceOperator { get; set; }
	}
}

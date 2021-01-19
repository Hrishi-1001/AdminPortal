using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Web.Models
{

	public class User : IdentityUser
	{
		public string ID { get; set; }
		public string Name { get; set; }
		public override string PasswordHash { get; set; }
		public Role Role { get; set; }

		public User()
		{
			
		}
	}
}

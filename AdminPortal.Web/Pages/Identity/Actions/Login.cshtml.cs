using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdminPortal.Repository;

namespace AdminPortal.Web.Pages.Identity.Actions
{
	[AllowAnonymous]
	public class LoginModel : PageModel
	{
		public static bool InvalidEntry = false;
		private readonly IUserRepository userRepository;

		public IUserRepository UserRepository { get; set; }

		public LoginModel(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public void OnPost(string phoneNumber, string password)
		{
			UserRepository = userRepository;
			var user = UserRepository.GetExact(phoneNumber);
			if (user != null && !user.IsLoggedIn && user.Authenticates(password))
			{
				Response.Redirect("/Home");
			}
		}
	}
}

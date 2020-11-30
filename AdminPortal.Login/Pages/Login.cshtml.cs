using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPortal.Data;
using AdminPortal.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPortal.Login.Pages
{
	[AllowAnonymous]
	public class LoginModel : PageModel
	{
		private readonly IUserRepository userRepository;

		public IUserRepository UserRepository { get; set; }

		public LoginModel(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public void OnPost(string phoneNumber, string password)
		{
			User user = userRepository.GetExact(phoneNumber);
			if (user != null && !user.IsLoggedIn && user.Authenticates(password))
			{
				Response.Redirect("/Home");
			}
		}
	}
}

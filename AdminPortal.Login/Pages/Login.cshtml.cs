using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AdminPortal.Models;
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
			if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phoneNumber))
			{
				Response.Redirect("/Login");
			}
			else
			{
				var pass_hash = Encoding.ASCII.GetString((SHA256.Create()).ComputeHash((Encoding.ASCII.GetBytes(password))));
				User user = userRepository.GetExact(phoneNumber);
				if (user != null && !user.IsLoggedIn && user.Authenticates(pass_hash))
				{
					Response.Redirect("/Home");
				}
				else
				{
					Response.Redirect("/Login");
				}
			}
		}
	}
}

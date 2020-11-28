using AdminPortal.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
			Data.User user = UserRepository.GetExact(phoneNumber);
			if (user != null && !user.IsLoggedIn && user.Authenticates(password))
			{
				Response.Redirect("/Home");
			}
		}
	}
}

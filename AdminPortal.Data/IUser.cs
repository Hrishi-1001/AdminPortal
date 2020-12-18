namespace AdminPortal.Models
{
	public interface IUser
	{
		bool IsAdmin { get; set; }
		bool IsLoggedIn { get; set; }
		string Password { get; set; }
		string PhoneNumber { get; set; }

		bool Authenticates(string password);
	}
}

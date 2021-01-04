using System;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdminPortal.Models
{
	public class User
	{
		private string password;

		public User()
		{

		}
		public User(string phoneNumber, string password, bool isAdmin = false)
		{
			PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
			Password = password ?? throw new ArgumentNullException(nameof(password));
			IsAdmin = isAdmin;
		}

		public bool Authenticates(string password)
		{
			return Password.Equals(password);
		}

		//UserID and PK
		[Key]
		[DataType(DataType.PhoneNumber)]
		public string PhoneNumber { get; set; }

		//User Passphrase
		[DataType(DataType.Password)]
		public string Password { get => password; set => password = Encoding.ASCII.GetString((SHA256.Create()).ComputeHash((Encoding.ASCII.GetBytes(value)))); }

		//Admin Rights
		public bool IsAdmin { get; set; }

		//Already logged in check
		public bool IsLoggedIn { get; set; }

	}
}

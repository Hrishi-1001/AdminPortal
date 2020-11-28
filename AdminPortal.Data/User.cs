using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdminPortal.Data
{
	public class User
	{
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
		public string Password { get; set; }

		//Admin Rights
		public bool IsAdmin { get; set; }

		//Already logged in check
		public bool IsLoggedIn { get; set; }

	}
}

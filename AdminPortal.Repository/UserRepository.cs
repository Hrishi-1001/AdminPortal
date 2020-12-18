using AdminPortal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AdminPortal.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly AdminPortalDbContext adminPortalDbContext;
		readonly List<IUser> Users;

		public UserRepository(AdminPortalDbContext adminPortalDbContext)
		{
			this.adminPortalDbContext = adminPortalDbContext;
			Users = this.adminPortalDbContext.Users.ToList();
		}

		public List<IUser> GetAll()
		{
			return (from User in Users
					select User).ToList();
		}

		public List<IUser> GetMatching(string phoneNumber)
		{
			return (from user in Users
				   where user.PhoneNumber.Contains(phoneNumber)
				   select user).ToList();
		}

		public IUser GetExact(string phoneNumber)
		{
			var _user = from user in Users
						where user.PhoneNumber.Equals(phoneNumber)
						select user;
			if (!_user.Any())
			{
				return null;
			}
			else
			{
				return _user.ToList().First();
			}
		}

		public IUser GetExact(string phoneNumber, string password)
		{
			var user = GetExact(phoneNumber);
			if (user == null || user.Password != Encoding.ASCII.GetString(SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(password))))
			{
				return null;
			}
			else
			{
				return user;
			}
		}

	}
}

using AdminPortal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AdminPortal.Repository
{
	public interface IUserRepository
	{
		List<User> GetAll();
		List<User> GetMatching(string phoneNumber);
		User GetExact(string phoneNumber);
		User GetExact(string phoneNumber, string password);
	}

	public class UserRepository : IUserRepository
	{
		private readonly AdminPortalDbContext adminPortalDbContext;
		readonly List<User> Users;

		public UserRepository(AdminPortalDbContext adminPortalDbContext)
		{
			this.adminPortalDbContext = adminPortalDbContext;
			Users = this.adminPortalDbContext.Users.ToList();
		}

		public List<User> GetAll()
		{
			return (from User in Users
					select User).ToList();
		}

		public List<User> GetMatching(string phoneNumber)
		{
			return (from user in Users
				   where user.PhoneNumber.Contains(phoneNumber)
				   select user).ToList();
		}

		public User GetExact(string phoneNumber)
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

		public User GetExact(string phoneNumber, string password)
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

using System;
using System.Collections.Generic;
using System.Text;
using AdminPortal.Data;
using System.Linq;

namespace AdminPortal.Repository
{
	public interface IUserRepository
	{
		List<User> GetAll();
		List<User> GetMatching(string phoneNumber);
		User GetExact(string phoneNumber);
	}

	public class UserRepository : IUserRepository
	{
		private readonly AdminPortalDbContext adminPortalDbContext;
		List<User> Users;

		public UserRepository(AdminPortalDbContext adminPortalDbContext)
		{
			this.adminPortalDbContext = adminPortalDbContext;
			Users = adminPortalDbContext.Users.ToList();
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

		User IUserRepository.GetExact(string phoneNumber)
		{
			return (from user in Users
					where user.PhoneNumber.Equals(phoneNumber)
					select user).ToList().First();
		}

	}
}

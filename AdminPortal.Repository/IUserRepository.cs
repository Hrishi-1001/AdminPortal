using AdminPortal.Models;
using System.Collections.Generic;

namespace AdminPortal.Repository
{
	public interface IUserRepository
	{
		List<IUser> GetAll();
		List<IUser> GetMatching(string phoneNumber);
		IUser GetExact(string phoneNumber);
		IUser GetExact(string phoneNumber, string password);
	}
}

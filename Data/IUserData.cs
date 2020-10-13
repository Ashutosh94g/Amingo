using System.Collections.Generic;
using Amingo.Models;

namespace Amingo.Data
{
	public interface IUserData
	{
		bool SaveChanges();
		IEnumerable<User> GetAllUsers();
		User GetUserById(int id);

		void CreateUser(User newUser);
	}
}
using System.Collections.Generic;
using Amingo.Models;

namespace Amingo.Data
{
	public interface IUserData
	{
		IEnumerable<User> GetAllUsers();
		User GetUserById(int id);
	}
}
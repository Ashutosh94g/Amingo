using System.Collections.Generic;
using Amingo.Models;

namespace Amingo.Data
{
	public class MockUserData : IUserData
	{
		public IEnumerable<User> GetAllUsers()
		{
			var Users = new List<User>()
			{
				new User { id = 1, first_name = "Ashutosh", last_name = "Modi", age = 20, sex = Sex.male },
				new User { id = 2, first_name = "Amanpreet", last_name = "Kaur", age = 20, sex = Sex.male }
			};
			return Users;
		}

		public User GetUserById(int id)
		{
			return new User { id = 2, first_name = "Amanpreet", last_name = "Kaur", age = 20, sex = Sex.male };
		}
	}
}
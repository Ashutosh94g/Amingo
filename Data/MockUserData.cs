using System.Collections.Generic;
using Amingo.Dtos;
using Amingo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amingo.Data
{
	public class MockUserData : IUserData
	{
		public void CreateUser(User newUser)
		{
			throw new System.NotImplementedException();
		}

		public void DeleteUser(User deletingUser)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<User> GetAllUsers()
		{
			var Users = new List<User>()
			{
				new User { id = 1, first_name = "Ashutosh", last_name = "Modi", age = 20, sex = "male" },
				new User { id = 2, first_name = "Amanpreet", last_name = "Kaur", age = 20, sex = "female" }
			};
			return Users;
		}

		public User GetUserById(int id)
		{
			return new User { id = 2, first_name = "Amanpreet", last_name = "Kaur", age = 20, sex = "male" };
		}

		public bool SaveChanges()
		{
			throw new System.NotImplementedException();
		}

		public void UpdateUser(ActionResult<UserReadDto> originalUser)
		{
			throw new System.NotImplementedException();
		}
	}
}
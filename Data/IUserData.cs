using System.Collections.Generic;
using System.Threading.Tasks;
using Amingo.Dtos;
using Amingo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Amingo.Data
{
	public interface IUserData
	{
		bool SaveChanges();
		IEnumerable<User> GetAllUsers();
		User GetUserById(int id);

		void CreateUser(User newUser);
		void UpdateUser(UserUpdateDto originalUser);

		void DeleteUser(User deletingUser);
		//void UpdateUser(Task<ActionResult<User>> originalUser);
	}
}
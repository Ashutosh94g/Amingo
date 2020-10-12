using System.Collections.Generic;
using System.Linq;
using Amingo.Models;

namespace Amingo.Data
{
	public class MySqlUserData : IUserData
	{
		private readonly UserContext _context;

		public MySqlUserData(UserContext context)
		{
			_context = context;
		}
		public IEnumerable<User> GetAllUsers()
		{
			return _context.Users.ToList();
		}

		public User GetUserById(int id)
		{
			return _context.Users.FirstOrDefault(us => us.id == id);
		}
	}
}
using System;
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

		public void CreateUser(User newUser)
		{
			if (newUser == null)
			{
				throw new ArgumentNullException(nameof(newUser));
			}
			_context.Add(newUser);
		}

		public IEnumerable<User> GetAllUsers()
		{
			return _context.Users.ToList();
		}

		public User GetUserById(int id)
		{
			return _context.Users.FirstOrDefault(us => us.id == id);
		}

		public bool SaveChanges()
		{
			return (_context.SaveChanges() >= 0);
		}
	}
}
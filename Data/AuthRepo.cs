using System;
using System.Threading.Tasks;
using Amingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Amingo.Data
{
	public class AuthRepo : IAuthRepo
	{
		private readonly UserDataContext _context;

		public AuthRepo(UserDataContext context)
		{
			_context = context;
		}

		//register a user 
		public async Task<User> Register(User user, string password)
		{
			byte[] PasswordSalt, PasswordHash;
			PasswordHashGenerator(password, out PasswordHash, out PasswordSalt);
			user.PasswordHash = PasswordHash;
			user.PasswordSalt = PasswordSalt;

			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();

			return user;
		}

		//used for creating hash for storing password 
		private void PasswordHashGenerator(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new System.Security.Cryptography.HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}

		//login a user
		public async Task<User> Login(string username, string password)
		{
			var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

			if (user == null)
				return null;

			var passwordHash = user.PasswordHash;
			var passwordSalt = user.PasswordSalt;

			if (!VerifyPasswordHash(password, passwordHash, passwordSalt))
			{
				return null;
			}
			return user;
		}

		//verify if the password matches the entered password
		private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
			{
				var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
				for (int i = 0; i < computedHash.Length; i++)
				{
					if (passwordHash[i] != computedHash[i]) return false;
				}
				return true;
			}
		}

		public async Task<bool> UserExists(string username)
		{
			if (await _context.Users.AnyAsync(x => x.Username == username))
			{
				return true;
			}
			return false;
		}
	}
}
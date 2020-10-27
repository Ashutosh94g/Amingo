using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Amingo.Data
{
	public class AmingoRepo : IAmingoRepo
	{
		private readonly UserDataContext _context;

		public AmingoRepo(UserDataContext context)
		{
			_context = context;
		}
		public void Add<T>(T entity) where T : class
		{
			_context.Add(entity);
		}

		public void Delete<T>(T entity) where T : class
		{
			_context.Remove(entity);
		}

		public void Update<T>(T entity) where T : class
		{
			_context.Update(entity);
		}

		public async Task<Photo> GetMainPhoto(int userId)
		{
			return await _context.Photos.Where(p => p.UserId == userId).FirstOrDefaultAsync(p => p.IsMain);
		}

		public async Task<Photo> GetPhoto(int id)
		{
			var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);
			return photo;
		}

		public async Task<User> GetUser(int id)
		{
			var user = await _context.Users.Include(u => u.Photos).FirstOrDefaultAsync(u => u.Id == id);
			return user;
		}

		public async Task<IEnumerable<User>> GetUsers()
		{
			var users = await _context.Users.Include(u => u.Photos).ToListAsync();
			return users;
		}

		public async Task<bool> SaveAll()
		{
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
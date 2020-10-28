using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amingo.Helpers;
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

		public async Task<PagedList<User>> GetUsers(UserParams userParams)
		{
			var users = _context.Users.Include(u => u.Photos).OrderByDescending(u => u.LastActive).AsQueryable();

			users.Where(u => u.Id != userParams.UserId);
			users.Where(u => u.Gender == userParams.Gender);

			if (userParams.MinAge != 18 || userParams.MaxAge != 99)
			{
				var fromdob = DateTime.Now.AddYears(-userParams.MaxAge - 1);
				var todob = DateTime.Now.AddYears(-userParams.MinAge);

				users = users.Where(u => u.DateOfBirth >= fromdob && u.DateOfBirth <= todob);
			}
			if (!string.IsNullOrEmpty(userParams.OrderBy))
			{
				switch (userParams.OrderBy)
				{
					case "Created_at":
						users = users.OrderByDescending(u => u.Created_at);
						break;
					default:
						users = users.OrderByDescending(u => u.LastActive);
						break;
				}
			}

			return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
		}

		public async Task<bool> SaveAll()
		{
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
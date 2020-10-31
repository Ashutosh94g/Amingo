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
			var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
			return user;
		}

		public async Task<PagedList<User>> GetUsers(UserParams userParams)
		{
			var users = _context.Users.OrderByDescending(u => u.LastActive).AsQueryable();

			//logedIn user must not see his own id
			users = users.Where(u => u.Id != userParams.UserId);
			//filter ids of opposite gender
			users = users.Where(u => u.Gender == userParams.Gender);

			//filter out already liked users 
			var usersWithoutLikes = await GetUserLikes(userParams.UserId, false);
			users = users.Where(u => !usersWithoutLikes.Contains(u.Id));

			if (userParams.Likers)
			{
				var userLikers = await GetUserLikes(userParams.UserId, userParams.Likers);
				users = users.Where(u => userLikers.Contains(u.Id));
			}
			if (userParams.Likees)
			{
				var userLikees = await GetUserLikes(userParams.UserId, userParams.Likers);
				users = users.Where(u => userLikees.Contains(u.Id));
			}

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

		private async Task<IEnumerable<int>> GetUserLikes(int id, bool likers)
		{
			var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

			if (likers)
			{
				return user.Likers.Where(u => u.LikeeId == id).Select(i => i.LikerId);
			}
			else
			{
				return user.Likees.Where(u => u.LikerId == id).Select(i => i.LikeeId);
			}
		}

		public async Task<bool> SaveAll()
		{
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<Like> GetLike(int userId, int receiverId)
		{
			return await _context.Likes.FirstOrDefaultAsync(u => u.LikerId == userId && u.LikeeId == receiverId);
		}

		public async Task<Message> GetMessage(int id)
		{
			return await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
		}

		public async Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams)
		{
			var messages = _context.Messages.AsQueryable();

			switch (messageParams.MessageContainer)
			{
				case "Inbox":
					messages = messages.Where(u => u.ReceiverId == messageParams.UserId && u.ReceiverDelete == false);
					break;
				case "Outbox":
					messages = messages.Where(u => u.SenderId == messageParams.UserId && u.SenderDelete == false);
					break;
				default:
					messages = messages.Where(u => u.ReceiverId == messageParams.UserId && u.ReceiverDelete == false && u.IsRead == false);
					break;
			}
			messages = messages.OrderByDescending(d => d.MessageSent);
			return await PagedList<Message>.CreateAsync(messages, messageParams.PageNumber, messageParams.PageSize);
		}

		public async Task<IEnumerable<Message>> GetMessageThread(int userId, int receiverId)
		{
			var messages = await _context.Messages
				.Where(m => m.SenderId == userId && m.ReceiverId == receiverId && m.SenderDelete == false
					|| m.SenderId == receiverId && m.ReceiverId == userId && m.ReceiverDelete == false)
				.OrderByDescending(m => m.MessageSent)
				.ToListAsync();

			return messages;
		}

		public async Task<bool> CheckMatch(int userId, int receiverId)
		{
			var user1 = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
			var user2 = await _context.Users.FirstOrDefaultAsync(u => u.Id == receiverId);

			var like = _context.Likes
				.Where(l => l.LikeeId == user1.Id && l.LikerId == user2.Id && l.Match == true
					|| l.LikeeId == user2.Id && l.LikerId == user1.Id && l.Match == true);

			if (like == null)
				return false;
			return true;
		}

		public async Task<bool> CheckLike(int userId, int receiverId)
		{
			var like = await _context.Likes.FirstOrDefaultAsync(l => l.LikerId == userId && l.LikeeId == receiverId);
			if (like == null)
				return false;
			return true;
		}
	}
}
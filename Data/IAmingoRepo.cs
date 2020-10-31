using System.Collections.Generic;
using System.Threading.Tasks;
using Amingo.Helpers;
using Amingo.Models;

namespace Amingo.Data
{
	public interface IAmingoRepo
	{
		void Add<T>(T entity) where T : class;
		void Delete<T>(T entity) where T : class;
		Task<bool> SaveAll();
		Task<PagedList<User>> GetUsers(UserParams userParams);
		Task<User> GetUser(int id);
		Task<Photo> GetPhoto(int id);
		Task<Photo> GetMainPhoto(int userId);
		Task<Like> GetLike(int userId, int receiverId);
		Task<Message> GetMessage(int id);
		Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams);
		Task<IEnumerable<Message>> GetMessageThread(int userId, int receiverId);
		Task<bool> CheckMatch(int userId, int receiverId);
		Task<bool> CheckLike(int userId, int receiverId);
		void Update<T>(T entity) where T : class;
	}
}
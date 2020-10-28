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
		void Update<T>(T entity) where T : class;
	}
}
using Amingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Amingo.Data
{
	public class UserDataContext : DbContext
	{
		public UserDataContext(DbContextOptions<UserDataContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Photo> Photos { get; set; }
	}
}
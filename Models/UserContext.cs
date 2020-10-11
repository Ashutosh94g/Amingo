using Microsoft.EntityFrameworkCore;

namespace Amingo.Models
{
	public class UserContext : DbContext
	{
		public UserContext() { }
		public UserContext(DbContextOptions<UserContext> options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL("server=localhost;port=6000;database=amingodb;uid=root;password=MySql@1");
		}

		public DbSet<User> Users { get; set; }
	}
}
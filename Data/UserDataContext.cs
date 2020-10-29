using Amingo.Models;
using Microsoft.EntityFrameworkCore;

namespace Amingo.Data
{
	public class UserDataContext : DbContext
	{
		public UserDataContext(DbContextOptions<UserDataContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Photo> Photos { get; set; }
		public DbSet<Like> Likes { get; set; }
		public DbSet<Message> Messages { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Like>().HasKey(k => new { k.LikeeId, k.LikerId });
			builder.Entity<Like>().HasOne(u => u.Likee).WithMany(u => u.Likers).HasForeignKey(u => u.LikeeId).OnDelete(DeleteBehavior.Restrict);
			builder.Entity<Like>().HasOne(u => u.Liker).WithMany(u => u.Likees).HasForeignKey(u => u.LikerId).OnDelete(DeleteBehavior.Restrict);
			builder.Entity<Message>().HasOne(u => u.Sender).WithMany(m => m.MessagesSent).OnDelete(DeleteBehavior.Restrict);
			builder.Entity<Message>().HasOne(u => u.Receiver).WithMany(m => m.MessagesReceived).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
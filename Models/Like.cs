namespace Amingo.Models
{
	public class Like
	{
		public int LikeeId { get; set; }
		public int LikerId { get; set; }
		public virtual User Likee { get; set; }
		public virtual User Liker { get; set; }
		public bool Match { get; set; } = false;
	}
}
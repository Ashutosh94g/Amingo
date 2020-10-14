using Amingo.Models;

namespace Amingo.Dtos
{
	public class UserReadDto
	{
		public int id { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public int age { get; set; }
		public Sex sex { get; set; }
		public string photoUrl { get; set; }
		public string username { get; set; }
	}
}
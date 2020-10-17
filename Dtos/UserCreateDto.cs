using System.ComponentModel.DataAnnotations;

namespace Amingo.Dtos
{
	public class UserCreateDto
	{
		[Required]
		[MaxLength(20)]
		public string first_name { get; set; }
		[Required]
		[MaxLength(20)]
		public string last_name { get; set; }
		public int age { get; set; }
		public string sex { get; set; }
		public string photoUrl { get; set; }
		public string username { get; set; }
		public string password { get; set; }
	}
}
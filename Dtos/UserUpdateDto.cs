using System.ComponentModel.DataAnnotations;

namespace Amingo.Dtos
{
	public class UserUpdateDto
	{
		[Required]
		[MaxLength(20)]
		public string first_name { get; set; }
		[Required]
		[MaxLength(20)]
		public string last_name { get; set; }
		public string photoUrl { get; set; }

		[Required]
		[RegularExpression(@"^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")]
		public string username { get; set; }
		[Required]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)\S{6,20}$")]
		public string password { get; set; }
	}
}
using System.ComponentModel.DataAnnotations;

namespace Amingo.Dtos
{
	public class LoginAuthDto
	{
		[RegularExpression(@"^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")]
		public string Username { get; set; }

		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)\S{6,20}$")]
		public string Password { get; set; }
	}
}
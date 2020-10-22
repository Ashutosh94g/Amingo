using System.ComponentModel.DataAnnotations;

namespace Amingo.Dtos
{
	public class RegisterAuthDto
	{
		[Required]
		public string Username { get; set; }

		[Required]
		[MinLength(4, ErrorMessage = "Password too short")]
		public string Password { get; set; }
	}
}
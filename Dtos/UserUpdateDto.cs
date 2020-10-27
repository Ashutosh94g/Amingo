using System;
using System.ComponentModel.DataAnnotations;

namespace Amingo.Dtos
{
	public class UserUpdateDto
	{
		[Required]
		public string Username { get; set; }

		[Required]
		[MinLength(4, ErrorMessage = "Password too short")]
		public string Password { get; set; }

		[Required]
		public string KnowAs { get; set; }

		[Required]
		public string City { get; set; }

		[Required]
		public string Country { get; set; }
	}
}
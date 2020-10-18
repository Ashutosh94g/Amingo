using System;
using System.ComponentModel.DataAnnotations;

namespace Amingo.Models
{
	public class User
	{
		[Key]
		public int id { get; set; }
		[Required]
		[MaxLength(20)]
		public string first_name { get; set; }
		[Required]
		[MaxLength(20)]
		public string last_name { get; set; }
		[Required]
		public int age { get; set; }
		[Required]
		public string sex { get; set; }
		public string photoUrl { get; set; }
		[RegularExpression("^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")]
		public string username { get; set; }
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)\S{6,20}$")]
		public string password { get; set; }

	}
	public enum Sex
	{
		male, female, shemale, other
	}
}

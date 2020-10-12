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
		public Sex sex { get; set; }

	}
	public enum Sex
	{
		male, female, shemale, other
	}
}
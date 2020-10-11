using System;

namespace Amingo.Models
{
	public class User
	{
		public int id { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public int age { get; set; }
		public Sex sex { get; set; }

	}
	public enum Sex
	{
		male, female, shemale, other
	}
}
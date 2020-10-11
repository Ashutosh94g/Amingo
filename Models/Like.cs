using System;
using System.ComponentModel.DataAnnotations;

namespace Amingo.Models
{
	class Like
	{
		[Key]
		public int id { get; set; }
		public User Liked_user { get; set; }
		public User Liked_by { get; set; }

	}
}
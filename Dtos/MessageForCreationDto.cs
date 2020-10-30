using System;

namespace Amingo.Dtos
{
	public class MessageForCreationDto
	{
		public int SenderId { get; set; }
		public int ReceiverId { get; set; }
		public DateTime MessageSent { get; set; }
		public string Content { get; set; }
		public MessageForCreationDto()
		{
			MessageSent = DateTime.Now;
		}
	}
}
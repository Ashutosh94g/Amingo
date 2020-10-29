using System;

namespace Amingo.Models
{
	public class Message
	{
		public int Id { get; set; }
		public int SenderId { get; set; }
		public User Sender { get; set; }
		public int ReceiverId { get; set; }
		public User Receiver { get; set; }
		public string Content { get; set; }
		public bool IsRead { get; set; }
		public DateTime? DateRead { get; set; }
		public DateTime MessageSent { get; set; }
		public bool SenderDelete { get; set; }
		public bool ReceiverDelete { get; set; }
	}
}
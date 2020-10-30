using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amingo.Models;
using Amingo.Data;
using Microsoft.AspNetCore.Authorization;
using Amingo.Helpers;
using AutoMapper;
using System.Security.Claims;
using Amingo.Dtos;

namespace Amingo.Controllers
{
	[ServiceFilter(typeof(LogUserActivity))]
	[Authorize]
	[Route("api/users/{userId}/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		private readonly IAmingoRepo _repo;
		private readonly IMapper _mapper;

		public MessagesController(IAmingoRepo repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		[HttpGet("{id}", Name = nameof(GetMessage))]
		public async Task<IActionResult> GetMessage(int userId, int id)
		{
			if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
				return Unauthorized();

			var messageFromRepo = await _repo.GetMessage(id);

			if (messageFromRepo == null)
				return NotFound();

			return Ok(messageFromRepo);
		}
		[HttpGet]
		public async Task<IActionResult> GetMessagesForUser(int userId, [FromQuery] MessageParams messageParams)
		{
			if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
				return Unauthorized();

			messageParams.UserId = userId;

			var messagesFromRepo = await _repo.GetMessagesForUser(messageParams);
			var messages = _mapper.Map<IEnumerable<MessageToReturnDto>>(messagesFromRepo);
			Response.AddPagination(messagesFromRepo.CurrentPage, messagesFromRepo.PageSize,
				messagesFromRepo.TotalCount, messagesFromRepo.TotalPages);

			return Ok(messages);
		}

		[HttpGet("thread/{receiverId}")]
		public async Task<IActionResult> GetMessageThread(int userId, int receiverId)
		{
			if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
				return Unauthorized();

			var messageThread = await _repo.GetMessageThread(userId, receiverId);
			_mapper.Map<IEnumerable<MessageToReturnDto>>(messageThread);
			return Ok(messageThread);
		}

		[HttpPost]
		public async Task<IActionResult> CreateMessage(int userId, MessageForCreationDto messageForCreationDto)
		{
			var sender = await _repo.GetUser(userId);
			if (sender.Id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
				return Unauthorized();

			messageForCreationDto.SenderId = userId;
			var receiver = await _repo.GetUser(messageForCreationDto.ReceiverId);

			if (receiver == null)
			{
				return BadRequest("User not found");
			}

			var message = _mapper.Map<Message>(messageForCreationDto);
			_repo.Add(message);
			if (await _repo.SaveAll())
			{
				var messageToReturn = _mapper.Map<MessageForCreationDto>(message);
				return CreatedAtRoute(nameof(GetMessage), new { userId = userId, id = message.Id }, messageToReturn);
			}

			throw new Exception("Creating the message failed on save");
		}

		[HttpPost("{id}")]
		public async Task<IActionResult> DeleteMessage(int id, int userId)
		{
			if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
				return Unauthorized();

			var messageFromRepo = await _repo.GetMessage(id);

			if (messageFromRepo.SenderId == userId)
				messageFromRepo.SenderDelete = true;

			if (messageFromRepo.ReceiverId == userId)
				messageFromRepo.ReceiverDelete = true;

			if (messageFromRepo.SenderDelete && messageFromRepo.ReceiverDelete)
				_repo.Delete(messageFromRepo);

			if (await _repo.SaveAll())
				return NoContent();

			throw new Exception("Error deleting the message");
		}

		[HttpPost("{id}/read")]
		public async Task<IActionResult> MarkMessageAsRead(int id, int userId)
		{
			if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
				return Unauthorized();

			var message = await _repo.GetMessage(id);

			if (message.ReceiverId != userId)
				return Unauthorized();

			message.IsRead = true;
			message.DateRead = DateTime.Now;

			await _repo.SaveAll();

			return NoContent();
		}
	}
}
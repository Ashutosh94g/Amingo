using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amingo.Models;
using Amingo.Data;
using AutoMapper;
using Amingo.Dtos;

namespace Amingo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserData _userData;
		private readonly IMapper _mapper;

		public UsersController(IUserData userData, IMapper mapper)
		{
			_userData = userData;
			_mapper = mapper;
		}

		[HttpGet("")]
		public async Task<ActionResult<IEnumerable<UserReadDto>>> GetUsers()
		{
			// TODO: Your code here
			await Task.Yield();
			var userList = _userData.GetAllUsers();

			return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userList));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetUserById(int id)
		{
			// TODO: Your code here
			await Task.Yield();

			var user = _userData.GetUserById(id);
			if (user != null)
			{
				return Ok(_mapper.Map<UserReadDto>(user));
			}
			return NotFound();

		}
	}
}
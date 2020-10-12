using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amingo.Models;
using Amingo.Data;

namespace Amingo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserData _userData;
		public UsersController(IUserData userData)
		{
			_userData = userData;
		}

		[HttpGet("")]
		public async Task<ActionResult<IEnumerable<User>>> GetUsers()
		{
			// TODO: Your code here
			await Task.Yield();
			var userList = _userData.GetAllUsers();

			return Ok(userList);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetUserById(int id)
		{
			// TODO: Your code here
			await Task.Yield();

			return null;
		}

		[HttpPost("")]
		public async Task<ActionResult<User>> PostUser(User model)
		{
			// TODO: Your code here
			await Task.Yield();

			return null;
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutUser(int id, User model)
		{
			// TODO: Your code here
			await Task.Yield();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<User>> DeleteUserById(int id)
		{
			// TODO: Your code here
			await Task.Yield();

			return null;
		}
	}
}
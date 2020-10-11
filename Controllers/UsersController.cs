using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amingo.Models;

namespace Amingo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		public UsersController()
		{
		}

		[HttpGet("")]
		public async Task<ActionResult<IEnumerable<User>>> GetUsers()
		{
			// TODO: Your code here
			await Task.Yield();

			return new List<User> {
				new User(){id=1, first_name="Ashutosh", last_name="Modi", age=20, sex=Sex.male}
			};
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
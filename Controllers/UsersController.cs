using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Amingo.Data;
using Amingo.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amingo.Controller
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly IAmingoRepo _repo;
		private readonly IMapper _mapper;

		public UsersController(IAmingoRepo repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetUsers()
		{
			var users = await _repo.GetUsers();
			var usersToReturn = _mapper.Map<IEnumerable<UserListDto>>(users);

			return Ok(usersToReturn);
		}

		// [AllowAnonymous]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetUser(int id)
		{
			var user = await _repo.GetUser(id);
			var userToReturn = _mapper.Map<UserDetailedDto>(user);
			return Ok(userToReturn);
		}
	}
}
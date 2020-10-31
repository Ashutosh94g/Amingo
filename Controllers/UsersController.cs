using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Amingo.Data;
using Amingo.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using System.Security.Claims;
using Amingo.Helpers;
using Amingo.Models;

namespace Amingo.Controller
{
	[ServiceFilter(typeof(LogUserActivity))]
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
		//****************************************from query is used for telling the http to use initial values from query string
		public async Task<IActionResult> GetUsers([FromQuery] UserParams userParams)
		{
			//getting id from the token and saving the value in userParams
			userParams.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
			//getting the user from the repo from the id
			var userFromRepo = await _repo.GetUser(userParams.UserId);

			if (string.IsNullOrEmpty(userParams.Gender))
			{
				userParams.Gender = userFromRepo.Gender == "male" ? "female" : "male";
			}


			var users = await _repo.GetUsers(userParams);
			var usersToReturn = _mapper.Map<IEnumerable<UserListDto>>(users);

			//adding pagination information to the response header
			//since we are in apiController we have access to Response
			Response.AddPagination(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

			return Ok(usersToReturn);
		}

		// [AllowAnonymous]
		[HttpGet("{id}", Name = nameof(GetUser))]
		public async Task<IActionResult> GetUser(int id)
		{
			var user = await _repo.GetUser(id);
			var userToReturn = _mapper.Map<UserDetailedDto>(user);
			return Ok(userToReturn);
		}

		[HttpPatch("{id}")]
		public async Task<IActionResult> UpdateUser(int id, JsonPatchDocument<UserUpdateDto> userPatchUpdateDto)
		{
			if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
				return Unauthorized();
			var user = await _repo.GetUser(id);
			var userToPatch = _mapper.Map<UserUpdateDto>(user);

			userPatchUpdateDto.ApplyTo(userToPatch, ModelState);
			if (!TryValidateModel(userToPatch))
			{
				ValidationProblem(ModelState);
			}

			_mapper.Map(userToPatch, user);
			if (await _repo.SaveAll())
			{
				return NoContent();
			}
			return BadRequest("Fields cannot be updated");
		}

		[HttpPost("{id}/like/{receiverId}")]
		public async Task<IActionResult> LikeUser(int id, int receiverId)
		{
			if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
				return Unauthorized();

			//Checking if the user already liked recipient user 
			var like = await _repo.GetLike(id, receiverId);
			var reverseLike = await _repo.GetLike(receiverId, id);

			if (like != null)
			{
				return BadRequest("User already liked");
			}

			if (await _repo.GetUser(receiverId) == null)
			{
				return NotFound();
			}

			//first like
			if (like == null && reverseLike == null)
			{
				like = new Like
				{
					LikeeId = receiverId,
					LikerId = id
				};
				_repo.Add<Like>(like);
			}

			//Match like
			if (reverseLike != null)
			{
				reverseLike.Match = true;
			}


			if (await _repo.SaveAll())
			{
				if (reverseLike != null)
					return Ok(_mapper.Map<LikeToReturnDto>(reverseLike));
				// client side check if userId == response.data.likerId then first like else match like
				return Ok(_mapper.Map<LikeToReturnDto>(like));
			}


			return BadRequest("Failed to like user");
		}
	}
}
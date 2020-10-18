using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amingo.Models;
using Amingo.Data;
using AutoMapper;
using Amingo.Dtos;
using Microsoft.AspNetCore.JsonPatch;

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

		[HttpGet]
		public ActionResult<IEnumerable<UserReadDto>> GetUsers()
		{
			// TODO: Your code here
			var userList = _userData.GetAllUsers();

			return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userList));
		}

		[HttpGet("{id}", Name = "GetUserById")]
		public ActionResult<UserReadDto> GetUserById(int id)
		{
			// TODO: Your code here

			var user = _userData.GetUserById(id);
			if (user != null)
			{
				return Ok(_mapper.Map<UserReadDto>(user));
			}
			return NotFound();
		}

		[HttpPost]
		public ActionResult<UserReadDto> CreateUser(UserCreateDto newUser)
		{
			var userModelObj = _mapper.Map<User>(newUser);
			_userData.CreateUser(userModelObj);
			_userData.SaveChanges();
			var userReadObj = _mapper.Map<UserReadDto>(userModelObj);

			// return CreatedAtRoute(nameof(GetUserById), new { id = userReadObj.id, userReadObj });
			return NoContent();
		}

		[HttpPut("{id}")]
		public ActionResult PutUser(int id, UserUpdateDto updatedPutUser)
		{
			var userModel = _userData.GetUserById(id);
			if (userModel == null)
			{
				return NotFound();
			}
			_mapper.Map(updatedPutUser, userModel);
			var userUpdateDto = _mapper.Map<UserUpdateDto>(userModel);
			_userData.UpdateUser(userUpdateDto);
			_userData.SaveChanges();

			return NoContent();
		}

		[HttpPatch("{id}")]
		public ActionResult PatchUser(int id, JsonPatchDocument<UserUpdateDto> updatedPatchUser)
		{
			var originalUser = _userData.GetUserById(id);
			if (originalUser == null)
			{
				return NotFound();
			}
			var userToPatch = _mapper.Map<UserUpdateDto>(originalUser);
			updatedPatchUser.ApplyTo(userToPatch, ModelState);

			if (!TryValidateModel(userToPatch))
			{
				return ValidationProblem(ModelState);
			}

			_mapper.Map(userToPatch, originalUser);
			_userData.UpdateUser(_mapper.Map<UserUpdateDto>(originalUser));
			_userData.SaveChanges();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteUser(int id)
		{
			var deletingUser = _userData.GetUserById(id);
			if (deletingUser == null)
			{
				return NotFound();
			}
			_userData.DeleteUser(_mapper.Map<User>(deletingUser));
			_userData.SaveChanges();
			return NoContent();
		}
	}
}
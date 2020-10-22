using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Amingo.Dtos;
using Amingo.Data;
using Amingo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace Barlow.Controller
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthRepo _repo;
		private readonly IConfiguration _config;

		public AuthController(IAuthRepo repo, IConfiguration config)
		{
			_repo = repo;
			_config = config;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterAuthDto registerAuthDto)
		{
			//usernames are all lowercase and to ensure it
			registerAuthDto.Username = registerAuthDto.Username.ToLower();
			if (await _repo.UserExists(registerAuthDto.Username))
			{
				return BadRequest("Username already taken! please use another one");
			}
			var userToCreate = new User
			{
				Username = registerAuthDto.Username
			};
			var created_user = await _repo.Register(userToCreate, registerAuthDto.Password);
			return StatusCode(201);
		}

		[HttpGet("Login")]
		public async Task<IActionResult> Login(LoginAuthDto loginAuthDto)
		{
			//check if user exists
			var user = await _repo.Login(loginAuthDto.Username.ToLower(), loginAuthDto.Password);
			if (user == null)
				return Unauthorized();


			//claims are basically the data which will be send back along with token from server to client
			var claims = new[]
			{
								new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
								new Claim(ClaimTypes.Name, user.Username)
						};

			//key is used to encrypt the token which will be suplied to client
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

			//key is used to encrypt the token along with a encrypting algorithm
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			//start creating token with defining a token descriptor 
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddDays(1),//expire time must be random 
				SigningCredentials = creds
			};


			//a token handler is created which will create a token
			var tokenHandler = new JwtSecurityTokenHandler();

			//token is created based on token descriptor
			var token = tokenHandler.CreateToken(tokenDescriptor);

			return Ok(new
			{
				//write token parts which is too send back to client
				token = tokenHandler.WriteToken(token)
			});
		}
	}
}
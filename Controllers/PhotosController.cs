using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Amingo.Data;
using Amingo.Dtos;
using Amingo.Helpers;
using Amingo.Models;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Amingo.Controller
{
	[ApiController]
	[Route("api/users/{userId}/photos")]
	[Authorize]
	public class PhotosController : ControllerBase
	{
		private readonly IAmingoRepo _repo;
		private readonly IMapper _mapper;
		private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
		private readonly Cloudinary _cloudinary;

		public PhotosController(IAmingoRepo repo, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
		{
			_repo = repo;
			_mapper = mapper;
			_cloudinaryConfig = cloudinaryConfig;

			Account acc = new Account(
				_cloudinaryConfig.Value.Cloudname,
				_cloudinaryConfig.Value.ApiKey,
				_cloudinaryConfig.Value.ApiSecret
			);

			_cloudinary = new Cloudinary(acc);
		}

		[HttpGet("{id}", Name = nameof(GetPhoto))]
		public async Task<IActionResult> GetPhoto(int id)
		{
			var photoFromRepo = await _repo.GetPhoto(id);
			var photo = _mapper.Map<PhotoForReturnDto>(photoFromRepo);

			return Ok(photo);
		}

		[HttpPost]
		public async Task<IActionResult> AddPhotoForUser(int UserId, [FromForm] PhotoForCreationDto photoForCreationDto)
		{
			if (UserId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
				return Unauthorized();
			var userFromRepo = await _repo.GetUser(UserId);

			var file = photoForCreationDto.File;
			var uploadResult = new ImageUploadResult();

			if (file.Length > 0)
			{
				//file is read if file is not empty
				using (var stream = file.OpenReadStream())
				{
					var uploadParams = new ImageUploadParams()
					{
						//pass the file discription 
						File = new FileDescription(file.Name, stream),
						Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
					};
					uploadResult = _cloudinary.Upload(uploadParams);
				}
			}
			photoForCreationDto.Url = uploadResult.Url.ToString();
			photoForCreationDto.PublicId = uploadResult.PublicId;

			var photo = _mapper.Map<Photo>(photoForCreationDto);

			if (!userFromRepo.Photos.Any(u => u.IsMain))
			{
				photo.IsMain = true;
			}

			userFromRepo.Photos.Add(photo);

			if (await _repo.SaveAll())
			{
				var photoToReturn = _mapper.Map<PhotoForReturnDto>(photo);
				//pass all the parameters which are required in url
				return CreatedAtRoute(nameof(GetPhoto), new { UserId, id = photo.Id }, photoToReturn);
			}
			return BadRequest("Photo cannot be uploaded");
		}

		[HttpPost("{id}/isMain")]
		public async Task<IActionResult> SetMainPhoto(int userId, int id)
		{
			//checking if the token is for the same user or not
			if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
			{
				return Unauthorized();
			}
			var user = await _repo.GetUser(userId);

			//checking if the photo id is valid
			if (!user.Photos.Any(p => p.Id == id))
			{
				return Unauthorized();
			}
			var photoFromRepo = await _repo.GetPhoto(id);

			//checking if the photo is already main or not
			if (photoFromRepo.IsMain)
			{
				return BadRequest("Photo is already main");
			}
			var currentMainPhoto = await _repo.GetMainPhoto(userId);

			//switching the main photo 
			currentMainPhoto.IsMain = false;
			photoFromRepo.IsMain = true;

			//saving all changes into the database
			if (await _repo.SaveAll())
			{
				return NoContent();
			}

			return BadRequest("The Photo cannot be changed to the main photo");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePhoto(int userId, int id)
		{
			//checking if the token is for the same user or not
			if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
			{
				return Unauthorized();
			}
			var user = await _repo.GetUser(userId);

			//checking if the photo id is valid
			if (!user.Photos.Any(p => p.Id == id))
			{
				return Unauthorized();
			}
			var photoFromRepo = await _repo.GetPhoto(id);

			//checking if the photo is already main or not
			if (photoFromRepo.IsMain)
			{
				return BadRequest("Cannot delete your main photo");
			}

			//if the url is of cloudinary or not 
			if (photoFromRepo.PublicId != null)
			{
				var deletionParams = new DeletionParams(photoFromRepo.PublicId);
				var response = await _cloudinary.DestroyAsync(deletionParams);

				if (response.Result == "ok")
				{
					_repo.Delete(photoFromRepo);
				}
			}
			else
			{
				_repo.Delete(photoFromRepo);
			}

			if (await _repo.SaveAll())
			{
				return Ok();
			}
			return BadRequest("Failed to delete the photo");
		}
	}
}
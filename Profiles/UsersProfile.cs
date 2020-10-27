using System.Linq;
using Amingo.Dtos;
using Amingo.Helpers;
using Amingo.Models;
using AutoMapper;

namespace Amingo.Profiles
{
	public class UsersProfile : Profile
	{
		//Source => destination
		public UsersProfile()
		{
			CreateMap<User, UserDetailedDto>()
					.ForMember(dest => dest.PhotoUrl,
							option => option.MapFrom(src =>
									src.Photos.FirstOrDefault(
											photo => photo.IsMain).Url))
					.ForMember(dest => dest.Age, option => option.MapFrom(src => src.DateOfBirth.CalculateAge()));


			CreateMap<User, UserListDto>()
					.ForMember(dest => dest.PhotoUrl,
									option => option.MapFrom(src =>
											src.Photos.FirstOrDefault(
													photo => photo.IsMain).Url))
					.ForMember(dest => dest.Age, option => option.MapFrom(src => src.DateOfBirth.CalculateAge()));


			CreateMap<Photo, PhotosForDetailedDto>();
			CreateMap<Photo, PhotoForReturnDto>();
			CreateMap<PhotoForCreationDto, Photo>();
			CreateMap<RegisterAuthDto, User>();
			CreateMap<UserUpdateDto, User>();
			CreateMap<User, UserUpdateDto>();
		}
	}
}
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
			CreateMap<MessageForCreationDto, Message>().ReverseMap();
			CreateMap<Message, MessageToReturnDto>()
				.ForMember(m => m.SenderPhotoUrl, option => option
					.MapFrom(m => m.Sender.Photos.FirstOrDefault(p => p.IsMain).Url))
				.ForMember(m => m.ReceiverPhotoUrl, option => option
					.MapFrom(m => m.Receiver.Photos.FirstOrDefault(p => p.IsMain).Url));

			CreateMap<Like, LikeToReturnDto>();
		}
	}
}
using Amingo.Dtos;
using Amingo.Models;
using AutoMapper;

namespace Amingo.Profiles
{
	public class UsersProfile : Profile
	{
		public UsersProfile()
		{
			//Source => destination
			CreateMap<User, UserReadDto>();
			CreateMap<UserCreateDto, User>();
			CreateMap<UserUpdateDto, User>();
			CreateMap<User, UserUpdateDto>();
		}
	}
}
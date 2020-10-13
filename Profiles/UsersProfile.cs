using Amingo.Dtos;
using Amingo.Models;
using AutoMapper;

namespace Amingo.Profiles
{
	public class UsersProfile : Profile
	{
		public UsersProfile()
		{
			CreateMap<User, UserReadDto>();
			CreateMap<UserCreateDto, User>();
		}
	}
}
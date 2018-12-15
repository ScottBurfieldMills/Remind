using AutoMapper;
using Remind.Dtos;
using Remind.Entities;

namespace Remind.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}

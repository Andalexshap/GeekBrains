using AutoMapper;
using UserApi.DataStore;
using UserApi.DataStore.Dto;

namespace UserApi.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, UserEntity>(MemberList.Source)
                .ForMember(x => x.SurName, o => o.MapFrom(e => e.Family))
                .ReverseMap();
        }
    }
}

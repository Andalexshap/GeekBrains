using AutoMapper;
using WebApiLibrary.DataStore.Entities;

namespace UserApi.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserProfile, UserEntity>(MemberList.Source).ReverseMap();
        }
    }
}

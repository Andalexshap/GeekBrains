using AutoMapper;
using WebApiLibrary.DataStore.Entities;
using WebApiLibrary.DataStore.Models;

namespace MessageApi.Mapper
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageEntity, MessageModel>(MemberList.Destination).ReverseMap();
        }
    }
}

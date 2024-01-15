using AutoMapper;
using ClientsBooksApi.DataStore;
using ClientsBooksApi.DataStore.Dto;

namespace ClientsBooksApi.Mapper
{
    public class ClientBookProfile : Profile
    {
        public ClientBookProfile()
        {
            CreateMap<ClientBookEntity, ClientBookDto>().ReverseMap();
        }
    }
}

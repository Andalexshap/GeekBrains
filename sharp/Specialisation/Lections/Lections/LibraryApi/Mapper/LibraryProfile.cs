using AutoMapper;
using LibraryApi.DataStore;
using LibraryApi.DataStore.Dto;

namespace LibraryApi.Mapper
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            CreateMap<AuthorEntity, AuthorDto>(MemberList.Destination).ReverseMap();
            CreateMap<BookEntity, BookDto>(MemberList.Destination).ReverseMap();
        }
    }
}

using AutoMapper;
using LibraryApi.DataStore;
using LibraryApi.DataStore.Dto;
using UserApi.DataStore;

namespace UserApi.Services
{
    public interface ILibraryService
    {
        void AddAuthor(AuthorDto author);
        void AddBook(BookDto book);
        public IEnumerable<AuthorDto> GetAuthors();
        public IEnumerable<BookDto> GetBooks();
        public bool CheckBook(Guid booksId);
    }
    public class LibraryService : ILibraryService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public LibraryService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddAuthor(AuthorDto author)
        {
            using (_context)
            {
                var entity = _mapper.Map<AuthorEntity>(author);
                _context.Authors.Add(entity);
                _context.SaveChanges();
            }
        }

        public void AddBook(BookDto book)
        {
            using (_context)
            {
                var entity = _mapper.Map<BookEntity>(book);
                _context.Books.Add(entity);
                _context.SaveChanges();
            }
        }

        public bool CheckBook(Guid booksId)
        {
            using (_context)
            {
                return _context.Books.FirstOrDefault(x => x.Id == booksId) != null;
            }
        }

        public IEnumerable<AuthorDto> GetAuthors()
        {
            using (_context)
            {
                return _context.Authors.Select(x => _mapper.Map<AuthorDto>(x)).ToList();
            }
        }

        public IEnumerable<BookDto> GetBooks()
        {
            using (_context)
            {
                return _context.Books.Select(x => _mapper.Map<BookDto>(x)).ToList();
            }
        }
    }
}

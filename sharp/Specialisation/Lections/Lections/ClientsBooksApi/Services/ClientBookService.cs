using AutoMapper;
using ClientsBooksApi.DataStore;
using ClientsBooksApi.DataStore.Dto;

namespace ClientsBooksApi.Services
{
    public interface IClientBookService
    {
        void ReturnBook(Guid bookId);
        void TekeBook(ClientBookDto book);
        IEnumerable<ClientBookDto> GetBooks(Guid clientId);
    }
    public class ClientBookService : IClientBookService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public ClientBookService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void ReturnBook(Guid bookId)
        {
            using (_context)
            {
                var book = _context.ClientBooks.Single(x => x.BookId == bookId);
                _context.ClientBooks.Remove(book);
                _context.SaveChanges();
            }
        }

        public void TekeBook(ClientBookDto book)
        {
            using (_context)
            {
                var entity = _mapper.Map<ClientBookEntity>(book);
                _context.ClientBooks.Add(entity);
                _context.SaveChanges();
            }
        }
        public IEnumerable<ClientBookDto> GetBooks(Guid clientId)
        {
            using (_context)
                return _context.ClientBooks
                    .Where(x => x.ClientId == clientId)
                    .Select(x => _mapper.Map<ClientBookDto>(x))
                    .ToList();
        }
    }
}

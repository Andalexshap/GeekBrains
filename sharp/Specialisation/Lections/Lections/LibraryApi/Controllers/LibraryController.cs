using LibraryApi.DataStore.Dto;
using Microsoft.AspNetCore.Mvc;
using UserApi.Services;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _repository;
        public LibraryController(ILibraryService repository)
        {
            _repository = repository;
        }

        [HttpPost("add_author")]
        public ActionResult AddAuthor(AuthorDto author)
        {
            _repository.AddAuthor(author);
            return Ok();
        }

        [HttpGet("authors")]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
        {
            return Ok(_repository.GetAuthors());
        }

        [HttpPost("add_book")]
        public ActionResult AddBook(BookDto book)
        {
            _repository.AddBook(book);
            return Ok();
        }

        [HttpGet("books")]
        public ActionResult<IEnumerable<BookDto>> GetBooks()
        {
            return Ok(_repository.GetBooks());
        }

        [HttpGet("check_book/{bookId}")]
        public ActionResult CheckBook(Guid bookId)
        {
            return Ok(_repository.CheckBook(bookId));
        }
    }
}

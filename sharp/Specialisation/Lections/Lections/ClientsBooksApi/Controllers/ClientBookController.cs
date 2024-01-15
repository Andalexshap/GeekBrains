using ClientsBooksApi.Client;
using ClientsBooksApi.DataStore.Dto;
using ClientsBooksApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientBookController : ControllerBase
    {
        private readonly IClientBookService _repository;
        public ClientBookController(IClientBookService repository)
        {
            _repository = repository;
        }

        [HttpPost("take_book")]
        public async Task<TakeBookResultDto> TakeBook(ClientBookDto record)
        {
            var userExistsTask = new LibraryUsersClient().Exist(record.ClientId ?? Guid.Empty);
            var bookExistTask = new LibraryBooksClient().Exist(record.BookId ?? Guid.Empty);

            var userExists = await userExistsTask;
            var bookExist = await bookExistTask;
            if (userExists && bookExist)
            {
                try
                {
                    _repository.TekeBook(record);
                    return new TakeBookResultDto { Success = true };
                }
                catch (Exception ex)
                {
                    if (ex is DbUpdateException &&
                        ex.InnerException is PostgresException &&
                        ex?.InnerException?.Message?.Contains("dublicate") == true)
                    {
                        return new TakeBookResultDto { Error = "Такую книгу уже взяли" };
                    }
                    throw;
                }
            }
            else
            {
                if (!userExists)
                    return new TakeBookResultDto { Error = "Пользователь не найден" };
                else
                    return new TakeBookResultDto { Error = "Книга не найдена" };
            }
        }

        [HttpGet("return_book{bookId}")]
        public ActionResult ReturnBook(Guid bookId)
        {
            _repository.ReturnBook(bookId);
            return Ok();
        }

        [HttpGet("books_list/{clientId}")]
        public ActionResult<IEnumerable<ClientBookDto>> GetClientBooks(Guid clientId)
        {
            var result = _repository.GetBooks(clientId);
            return Ok(result);
        }
    }
}
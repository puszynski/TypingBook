using System.Collections.Generic;
using DALLibrary.DomainModel;
using DALLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Book")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository) => _bookRepository = bookRepository;


        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookRepository.Get();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookRepository.Get(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }
    }
}

/// W API nie kontaktujemy się z DB - wykorzystujemy metody DALLibrary które kontaktują się z DB
/// Aby móc działać z zewn. projektami musisz skonfigurować CORS https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api
/// Dla cora`a: https://docs.microsoft.com/pl-pl/aspnet/core/security/cors?view=aspnetcore-2.1
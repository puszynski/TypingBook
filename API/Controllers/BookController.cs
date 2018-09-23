using System.Collections.Generic;
using System.Threading.Tasks;
using BLLLibrary.Helpers;
using DALLibrary.DomainModel;
using DALLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly BookHelper _bookHelper = new BookHelper();

        public BookController(IBookRepository bookRepository) => _bookRepository = bookRepository;

        // http://localhost:5000/api/book/documentation
        // (Get API documentation)
        [HttpGet]
        public IActionResult Documentation()
        {
            var info = "Please use: ../api/book/get/1 to get book object; Please use ../api/book/get/2/1 to get first divided book content";
            return Ok(info);
        }

        // http://localhost:5000/api/book/get/2 <- dlaczego nie działa dla api/book/1 ????
        // Get all book data by ID
        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _bookRepository.GetAsync(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }


        // http://localhost:5000/api/book/get/2/1
        // Get all book data by ID
        [HttpGet("{id}/{num}")]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Book>> Get(int id, int num)
        {
            var book = await _bookRepository.GetAsync(id);
            if (book == null)
                return NotFound();

            var dividedContent = _bookHelper.DivideBook(book.Content);
            if (dividedContent[num] == null)
                return NotFound();

            return Ok(dividedContent[num]);
        }
    }
}

/// W API nie kontaktujemy się z DB - wykorzystujemy do tego 
/// Aby móc działać z zewn. projektami musiałeś skonfigurować CORS;
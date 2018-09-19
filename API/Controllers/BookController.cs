using System.Collections.Generic;
using BLLLibrary.Helpers;
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
        private readonly BookHelper _bookHelper = new BookHelper();

        public BookController(IBookRepository bookRepository) => _bookRepository = bookRepository; // ctor :)
        
        // całość książki poprzez ID: api/book/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookRepository.Get(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }


        // całość książki poprzez ID w porcjach: api/book/1/1
        [HttpGet("{id}/{num}")]
        public IActionResult GetByPortion(int id, int num)
        {
            var book = _bookRepository.Get(id);
            if (book == null)
                return NotFound();            

            var dividedContent = _bookHelper.DivideBook(book.Content);

            return Ok(book);
        }
    }
}

/// W API nie kontaktujemy się z DB - wykorzystujemy do tego 
/// Aby móc działać z zewn. projektami musisz skonfigurować CORS (zrobione);
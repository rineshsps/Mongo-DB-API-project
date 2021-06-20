using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mongo.Database.Models;
using Mongo.Services.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mongo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices _bookServices;
        private readonly ILogger<BooksController> _logger;

        /// <summary>
        /// book services 
        /// </summary>
        /// <param name="bookServices"></param>
        public BooksController(IBookServices bookServices, ILogger<BooksController> logger)
        {
            _bookServices = bookServices;
            _logger = logger;
        }

        /// <summary>
        /// Get books 
        /// </summary>
        /// <returns>List of books</returns>
        [HttpGet]
        public IActionResult GetBooks()
        {
            try
            {
                return Ok(_bookServices.GetBooks());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception api/GetBooks");

                throw;
            }
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(string id)
        {
            try
            {
                var books = _bookServices.GetBook(id);

                if (books == null)
                {
                    _logger.LogError($"Book with id: {id}, hasn't been found in database.");
                    return NotFound();
                }
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception get books api/GetBook{id}");

                throw;
            }
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            try
            {
                _bookServices.Create(book);
                return CreatedAtRoute("GetBook", new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Add books api/AddBook");
                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(string id)
        {
            try
            {
                _bookServices.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Exeption DeleteBook api/DeleteBook");
                throw;
            }
        }

        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
            try
            {
                return Ok(_bookServices.Update(book));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exeption Update book api/UpdateBook");
                throw;
            }

        }
    }
}

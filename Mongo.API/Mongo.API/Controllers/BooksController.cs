using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mongo.DTOs;
using Mongo.Services.Interfaces;
using System;
using Book = Mongo.Database.Models.Book;

namespace Mongo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices _bookServices;
        private readonly ILogger<BooksController> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// book services 
        /// </summary>
        /// <param name="bookServices"></param>
        public BooksController(IBookServices bookServices, ILogger<BooksController> logger, IMapper mapper)
        {
            _bookServices = bookServices;
            _logger = logger;
            _mapper = mapper;
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

                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

                return StatusCode(500);
            }
        }

        /// <summary>
        /// Create book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddBook(BookCreateDTO book)
        {
            try
            {
                var model = _mapper.Map<Book>(book);
                var display = _bookServices.Create(model);
                return CreatedAtRoute("GetBook", new { id = display.Id }, display);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Add books api/AddBook");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Delete book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Update books
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>

        [HttpPut]
        public IActionResult UpdateBook(BookUpdateDTO book)
        {
            try
            {
                var model = _mapper.Map<Book>(book);
                return Ok(_bookServices.Update(model));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exeption Update book api/UpdateBook");
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("AggreageSample")]
        public dynamic AggreageSample()
        {
            try
            {
                return _bookServices.AggreageSample();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception get books api/AggreageSample");

                return StatusCode(500);
            }
        }
    }
}

using LibraryManager.Models;
using LibraryManager.Sevices.BookManger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LibraryManager.Controllers
{
    /// <summary>
    /// Controller for handling book-related API requests.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        /// <summary>
        /// The book service.
        /// </summary>
        private readonly IBookService _bookService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="bookService">The book service.</param>
        public BooksController(IBookService bookService)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }

        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns>List of all books.</returns>
        [HttpGet("get-all-books")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _bookService.GetAllBooksAsync(); 

                if (books == null || !books.Any())
                {
                    return NotFound("No books found.");
                }

                return Ok(books); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }

        /// <summary>
        /// Gets the book by identifier.
        /// </summary>
        /// <param name="id">The book identifier.</param>
        /// <returns>Book object if found, otherwise NotFound.</returns>
        [HttpGet("get-book/{id}", Name = "GetBookById")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(id); 

                if (book == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }

                return Ok(book); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }

        /// <summary>
        /// Adds a new book.
        /// </summary>
        /// <param name="book">The book object to add.</param>
        /// <returns>Created status with the book information.</returns>
        [HttpPost]
        [Route("add-book")]
        public async Task<IActionResult> AddBook([FromBody] Models.Book book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest("Invalid book data."); 
                }

                await _bookService.AddBookAsync(book); 

                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }

        /// <summary>
        /// Updates an existing book.
        /// </summary>
        /// <param name="id">The book identifier.</param>
        /// <param name="book">The book object with updated data.</param>
        /// <returns>NoContent status if the update is successful.</returns>
        [HttpPut("update-book/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Models.Book book)
        {
            try
            {
                if (book == null || id != book.Id)
                {
                    return BadRequest("Book data is invalid or ID mismatch."); 
                }

                var existingBook = await _bookService.GetBookByIdAsync(id);
                if (existingBook == null)
                {
                    return NotFound($"Book with ID {id} not found."); 
                }

                await _bookService.UpdateBookAsync(book); 

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }

        /// <summary>
        /// Deletes the book by identifier.
        /// </summary>
        /// <param name="id">The book identifier to delete.</param>
        /// <returns>NoContent status if the deletion is successful.</returns>
        [HttpDelete("delete-book/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var existingBook = await _bookService.GetBookByIdAsync(id);
                if (existingBook == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }

                await _bookService.DeleteBookAsync(id);

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }

        /// <summary>
        /// Searches books based on the provided keyword.
        /// </summary>
        /// <param name="keyword">The search keyword (title, author, genre).</param>
        /// <returns>A list of books matching the search keyword.</returns>
        [HttpGet("search-book")]
        public async Task<IActionResult> SearchBooks([FromQuery] string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    return BadRequest("Search keyword cannot be empty.");
                }

                var books = await _bookService.SearchBooksAsync(keyword); 

                if (books == null || !books.Any())
                {
                    return NotFound("No books found matching the search keyword.");
                }

                return Ok(books); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }
    }
}

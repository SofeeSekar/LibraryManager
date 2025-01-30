using LibraryManager.Models;
using LibraryManager.Sevices.AuthorManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    /// <summary>
    /// Controller for handling author-related API requests.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        /// <summary>
        /// The author service
        /// </summary>
        private readonly IAuthorService _authorService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorController"/> class.
        /// </summary>
        /// <param name="authorService">The author service.</param>
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        /// Gets all authors.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-authors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        /// <summary>
        /// Gets the author by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("get-author/{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
                return NotFound();
            return Ok(author);
        }

        // Get author by BookId
        /// <summary>
        /// Gets the author by book identifier.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>
        [HttpGet("get-author-by-book/{bookId}")]
        public async Task<IActionResult> GetAuthorByBookId(int bookId)
        {
            var author = await _authorService.GetAuthorByBookIdAsync(bookId);
            if (author == null)
                return NotFound();
            return Ok(author);
        }

        /// <summary>
        /// Adds the author.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("add-author")]

        public async Task<IActionResult> AddAuthor([FromBody] Author author)
        {
            await _authorService.AddAuthorAsync(author);
            return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, author);
        }

        /// <summary>
        /// Updates the author.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="author">The author.</param>
        /// <returns></returns>
        [HttpPut("update-author/{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] Author author)
        {
            if (id != author.Id) return BadRequest();
            await _authorService.UpdateAuthorAsync(author);
            return NoContent();
        }

        /// <summary>
        /// Deletes the author.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("delete-author/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}

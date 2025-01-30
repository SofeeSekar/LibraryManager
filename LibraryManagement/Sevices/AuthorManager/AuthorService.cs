using LibraryManagement.Models;
using LibraryManager.Data;
using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Sevices.AuthorManager
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="LibraryManager.Sevices.AuthorManager.IAuthorService" />
    /// <remarks>
    /// Initializes a new instance of the <see cref="AuthorService"/> class.
    /// </remarks>
    /// <param name="context">The context.</param>
    public class AuthorService(LibraryContext context) : IAuthorService
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly LibraryContext _context = context;

        /// <summary>
        /// Gets all authors asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        /// <summary>
        /// Gets the author by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }

        /// <summary>
        /// Gets the author by book identifier asynchronous.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>
        public async Task<Author> GetAuthorByBookIdAsync(int bookId)
        {
            var book = await _context.Books
                .Include(b => b.Author) // Include Author information
                .FirstOrDefaultAsync(b => b.Id == bookId);

            return book?.Author; // Return the Author if found
        }

        /// <summary>
        /// Adds the author asynchronous.
        /// </summary>
        /// <param name="author">The author.</param>
        public async Task AddAuthorAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the author asynchronous.
        /// </summary>
        /// <param name="author">The author.</param>
        public async Task UpdateAuthorAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the author asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }
    }
}

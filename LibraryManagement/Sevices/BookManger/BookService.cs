using LibraryManagement.Models;
using LibraryManager.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Sevices.BookManger
{
    /// <summary>
    /// Service for managing book-related operations, including CRUD actions and search functionality.
    /// </summary>
    public class BookService : IBookService
    {
        private readonly LibraryContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class.
        /// </summary>
        /// <param name="context">The <see cref="LibraryContext"/> used to interact with the database.</param>
        public BookService(LibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all books from the database, including their associated authors.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing a collection of all books.</returns>
        public async Task<IEnumerable<Models.Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync(); // Asynchronous operation to get books
        }

        /// <summary>
        /// Retrieves a book by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the book.</param>
        /// <returns>A task that represents the asynchronous operation, containing the book if found, otherwise null.</returns>
        public async Task<Models.Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == id); // Fetch book by ID
        }

        /// <summary>
        /// Adds a new book to the database.
        /// </summary>
        /// <param name="book">The book to be added.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task AddBookAsync(Models.Book book)
        {
            await _context.Books.AddAsync(book); // Asynchronously add book to context
            await _context.SaveChangesAsync(); // Save changes to the database
        }

        /// <summary>
        /// Updates the information of an existing book in the database.
        /// </summary>
        /// <param name="book">The book with updated information.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateBookAsync(Models.Book book)
        {
            _context.Books.Update(book); // Update the book in the context
            await _context.SaveChangesAsync(); // Save changes to the database
        }

        /// <summary>
        /// Deletes a book from the database by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the book to be deleted.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id); // Find the book by ID
            if (book != null)
            {
                _context.Books.Remove(book); // Remove the book from the context
                await _context.SaveChangesAsync(); // Save changes to the database
            }
        }

        /// <summary>
        /// Searches for books based on a keyword. The search can match the title, author, or genre of the book.
        /// </summary>
        /// <param name="keyword">The keyword to search for in book titles, authors, or genres.</param>
        /// <returns>A task that represents the asynchronous operation, containing a collection of matching books.</returns>
        public async Task<IEnumerable<Models.Book>> SearchBooksAsync(string keyword)
        {
            return await _context.Books
                .Where(b => b.Title.Contains(keyword) || b.Genre.Contains(keyword))
                .ToListAsync(); // Perform the search asynchronously
        }
    }
}

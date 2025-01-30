using LibraryManager.Models;

namespace LibraryManager.Sevices.BookManger
{
    /// <summary>
    /// Interface for managing book-related operations.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Retrieves all books from the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing a collection of all books.</returns>
        Task<IEnumerable<Models.Book>> GetAllBooksAsync();

        /// <summary>
        /// Retrieves a book by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the book.</param>
        /// <returns>A task that represents the asynchronous operation, containing the book if found, otherwise null.</returns>
        Task<Book> GetBookByIdAsync(int id);

        /// <summary>
        /// Adds a new book to the database.
        /// </summary>
        /// <param name="book">The book to be added.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddBookAsync(Book book);

        /// <summary>
        /// Updates the information of an existing book in the database.
        /// </summary>
        /// <param name="book">The book with updated information.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateBookAsync(Book book);

        /// <summary>
        /// Deletes a book from the database by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the book to be deleted.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteBookAsync(int id);

        /// <summary>
        /// Searches for books based on a keyword. The search can match the title, author, or genre of the book.
        /// </summary>
        /// <param name="keyword">The keyword to search for in book titles, authors, or genres.</param>
        /// <returns>A task that represents the asynchronous operation, containing a collection of matching books.</returns>
        Task<IEnumerable<Book>> SearchBooksAsync(string keyword);
    }
}

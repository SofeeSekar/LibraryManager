using LibraryManager.Models;

namespace LibraryManager.Sevices.AuthorManager
{
    /// <summary>
    /// Interface for managing author-related operations.
    /// </summary>
    public interface IAuthorService
    {
        /// <summary>
        /// Gets all authors asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        /// <summary>
        /// Gets the author by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Author> GetAuthorByIdAsync(int id);
        /// <summary>
        /// Gets the author by book identifier asynchronous.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>
        Task<Author> GetAuthorByBookIdAsync(int bookId); // Search authors by book ID
        /// <summary>
        /// Adds the author asynchronous.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <returns></returns>
        Task AddAuthorAsync(Author author);
        /// <summary>
        /// Updates the author asynchronous.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <returns></returns>
        Task UpdateAuthorAsync(Author author);
        /// <summary>
        /// Deletes the author asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task DeleteAuthorAsync(int id);
    }
}

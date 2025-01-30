using LibraryManager.Models;

namespace LibraryManagement.Models
{
    /// <summary>
    /// Contains the BorrowRecord details
    /// </summary>
    public class BorrowRecord
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the book identifier.
        /// </summary>
        /// <value>
        /// The book identifier.
        /// </value>
        public int BookId { get; set; }
        /// <summary>
        /// Gets or sets the book.
        /// </summary>
        /// <value>
        /// The book.
        /// </value>
        public Book? Book { get; set; }
      
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public int BorrowerId { get; set; }
        /// <summary>
        /// Gets or sets the borrowed date.
        /// </summary>
        /// <value>
        /// The borrowed date.
        /// </value>
        public DateTime BorrowedDate { get; set; }
        /// <summary>
        /// Gets or sets the returned date.
        /// </summary>
        /// <value>
        /// The returned date.
        /// </value>
        public DateTime? ReturnedDate { get; set; }
    }
}

namespace LibraryManagement.Models
{
    /// <summary>
    /// Contains the Borrower details
    /// </summary>
    public class Borrower
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public required string Name { get; set; }
        /// <summary>
        /// Gets or sets the borrowed books.
        /// </summary>
        /// <value>
        /// The borrowed books.
        /// </value>
        public ICollection<BorrowRecord> BorrowedBooks { get; set; } = new List<BorrowRecord>();
    }
}

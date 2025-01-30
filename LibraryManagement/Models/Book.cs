namespace LibraryManager.Models
{
    /// <summary>
    /// Contains the Book details
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public required string Title { get; set; }
        /// <summary>
        /// Gets or sets the genre.
        /// </summary>
        /// <value>
        /// The genre.
        /// </value>
        public required string Genre { get; set; }
        /// <summary>
        /// Gets or sets the author identifier.
        /// </summary>
        /// <value>
        /// The author identifier.
        /// </value>
        public int AuthorId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is borrowed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is borrowed; otherwise, <c>false</c>.
        /// </value>
        public bool IsBorrowed { get; set; }
        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        public Author? Author { get; set; }
    }
}

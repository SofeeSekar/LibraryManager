using LibraryManagement.Models;

namespace LibraryManager.Sevices.BorrowerManager
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBorrowerService
    {
        /// <summary>
        /// Gets all borrowers asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Borrower>> GetAllBorrowersAsync();
        /// <summary>
        /// Gets the borrower by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Borrower> GetBorrowerByIdAsync(int id);
        /// <summary>
        /// Adds the borrower asynchronous.
        /// </summary>
        /// <param name="borrower">The borrower.</param>
        /// <returns></returns>
        Task AddBorrowerAsync(Borrower borrower);
        /// <summary>
        /// Updates the borrower asynchronous.
        /// </summary>
        /// <param name="borrower">The borrower.</param>
        /// <returns></returns>
        Task UpdateBorrowerAsync(Borrower borrower);
        /// <summary>
        /// Deletes the borrower asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task DeleteBorrowerAsync(int id);
    }
}

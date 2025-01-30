using LibraryManagement.Models;
using LibraryManager.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Sevices.BorrowerManager
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IBorrowerService" />
    public class BorrowerService : IBorrowerService
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly LibraryContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BorrowerService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BorrowerService(LibraryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all borrowers asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Borrower>> GetAllBorrowersAsync()
        {
            return await _context.Borrowers.Include(b => b.BorrowedBooks)
                .ThenInclude(br => br.Book)
                .ToListAsync();
        }

        /// <summary>
        /// Gets the borrower by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Borrower> GetBorrowerByIdAsync(int id)
        {
            return await _context.Borrowers.Include(b => b.BorrowedBooks)
                .ThenInclude(br => br.Book)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        /// <summary>
        /// Adds the borrower asynchronous.
        /// </summary>
        /// <param name="borrower">The borrower.</param>
        public async Task AddBorrowerAsync(Borrower borrower)
        {
            _context.Borrowers.Add(borrower);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the borrower asynchronous.
        /// </summary>
        /// <param name="borrower">The borrower.</param>
        public async Task UpdateBorrowerAsync(Borrower borrower)
        {
            _context.Borrowers.Update(borrower);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the borrower asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task DeleteBorrowerAsync(int id)
        {
            var borrower = await _context.Borrowers.FindAsync(id);
            if (borrower != null)
            {
                _context.Borrowers.Remove(borrower);
                await _context.SaveChangesAsync();
            }
        }
    }
}

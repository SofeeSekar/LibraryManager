using LibraryManagement.Models;
using LibraryManager.Sevices.BorrowerManager;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers
{
    /// <summary>
    /// Controller for handling borrower-related API requests.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowersController : ControllerBase
    {
        /// <summary>
        /// The borrower service
        /// </summary>
        private readonly IBorrowerService _borrowerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BorrowersController"/> class.
        /// </summary>
        /// <param name="borrowerService">The borrower service.</param>
        public BorrowersController(IBorrowerService borrowerService)
        {
            _borrowerService = borrowerService;
        }

        // GET api/borrowers
        /// <summary>
        /// Gets all borrowers.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-authors")]
        public async Task<IActionResult> GetAllBorrowers()
        {
            var borrowers = await _borrowerService.GetAllBorrowersAsync();
            return Ok(borrowers);
        }

        /// <summary>
        /// Gets the borrower by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("get-borrower/{id}")]
        public async Task<IActionResult> GetBorrowerById(int id)
        {
            var borrower = await _borrowerService.GetBorrowerByIdAsync(id);
            if (borrower == null)
                return NotFound();
            return Ok(borrower);
        }

        /// <summary>
        /// Adds the borrower.
        /// </summary>
        /// <param name="borrower">The borrower.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("add-borrower")]

        public async Task<IActionResult> AddBorrower([FromBody] Borrower borrower)
        {
            await _borrowerService.AddBorrowerAsync(borrower);
            return CreatedAtAction(nameof(GetBorrowerById), new { id = borrower.Id }, borrower);
        }

        /// <summary>
        /// Updates the borrower.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="borrower">The borrower.</param>
        /// <returns></returns>
        [HttpPut("update-borrower/{id}")]

        public async Task<IActionResult> UpdateBorrower(int id, [FromBody] Borrower borrower)
        {
            // Check if the provided ID matches the borrower ID in the request body
            if (id != borrower.Id)
            {
                return BadRequest("Borrower ID in the URL doesn't match the ID in the request body.");
            }

            // Attempt to find the borrower by ID in the database
            var existingBorrower = await _borrowerService.GetBorrowerByIdAsync(id);
            if (existingBorrower == null)
            {
                return NotFound($"Borrower with ID {id} not found.");
            }

            // Update the borrower information
            await _borrowerService.UpdateBorrowerAsync(borrower);

            // Return a no-content response if the update was successful
            return NoContent();
        }

        /// <summary>
        /// Deletes the borrower.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("delete-borrower/{id}")]

        public async Task<IActionResult> DeleteBorrower(int id)
        {
            // Attempt to find the borrower by ID
            var existingBorrower = await _borrowerService.GetBorrowerByIdAsync(id);
            if (existingBorrower == null)
            {
                return NotFound($"Borrower with ID {id} not found.");
            }

            // Delete the borrower
            await _borrowerService.DeleteBorrowerAsync(id);

            return NoContent();
        }
    }
}

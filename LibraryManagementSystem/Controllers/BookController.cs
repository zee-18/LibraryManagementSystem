using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Issuebook")]
        public async Task<IActionResult> IssueBook(string userId, Guid copyId)
        {
            if (_context.BookHistory == null)
            {
                return NotFound();
            }
            if (userId == null || copyId == Guid.Empty)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Invalid user Id" });
            }
            var bookDetails = new BookHistory
            {
                HistoryId = Guid.NewGuid(),
                CopyId = copyId,
                UserId = userId,
                IssueDate = DateTime.Now,
                DueDate = DateTime.Now.AddMinutes(5),
                ReturnedDate = null
            };
            _context.BookHistory.Add(bookDetails);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "Book successfully issued" });

        }
    }
}

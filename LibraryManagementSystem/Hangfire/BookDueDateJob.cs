using LibraryManagementSystem.Models;
using LibraryManagementSystem.SignalRHub;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Hangfire
{
    public class BookDueDateJob
    {
        private readonly ApplicationDbContext dbContext;
        private readonly BookDueNotificationHub notificationHub;
        public BookDueDateJob(ApplicationDbContext _dbContext, BookDueNotificationHub _notificationHub)
        { 
            dbContext = _dbContext;
            notificationHub = _notificationHub;
        }
        public async Task CheckDueDate()
        {
            try
            {
                if (dbContext.BookHistory != null)
                {
                    var bookList = await dbContext.BookHistory.Where(x => x.ReturnedDate == null).ToListAsync();
                    foreach (var item in bookList)
                    {
                        if (item.DueDate <= DateTime.Now)
                        {
                            //Send email
                            //send notification
                            //var book =  from history in dbContext.BookHistory
                            //                 join copy in dbContext.BookCopy 
                            //                 on history.CopyId equals copy.CopyId 
                            //                 join books in dbContext.Books
                            //                 on copy.BookId equals books.BookId where copy.BookId == item.CopyId
                            //                 select new
                            //                 { 
                            //                    bookName = books.BookName,
                            //                    copyNumber = copy.BookId
                            //                 };
                            //await notificationHub.SendNotification($"{})}");
                            await notificationHub.SendNotification("Book is due, please follow up from the user");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // log here
                throw;
            }
            finally 
            {
                // i can dispose the dbcontext object 
                // but hangfire internally handles it
            }
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models.Library
{
    public class BookCopy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "CopyId is required")]
        public Guid CopyId { get; set; }

        public Guid? BookId { get; set; }
        public bool? Status { get; set; }
    }
}

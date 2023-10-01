using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models.Library
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "BookId is required")]
        public Guid BookId { get; set; }

        [Required(ErrorMessage = "BookName is required")]
        public string? BookName { get; set; }

        public string? Genre { get; set; }
        public Guid? AuthorId { get; set; }

        public DateTime? PublicationYear { get; set; }
    }
}

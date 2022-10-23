using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entities
{
    public class ApplicationUserBook
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; } = null!;

        public ApplicationUser ApplicationUser { get; set; } = null!;

        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        public Book Book { get; set; } = null!;
    }
}

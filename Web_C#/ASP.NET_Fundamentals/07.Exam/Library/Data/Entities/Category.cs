using System.ComponentModel.DataAnnotations;
using static Library.Data.ValidationConstants.CategoryConstants;

namespace Library.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}

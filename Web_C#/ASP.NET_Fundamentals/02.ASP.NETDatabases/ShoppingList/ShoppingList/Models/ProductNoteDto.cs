using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public class ProductNoteDto
    {
        public Guid Id { get; set; }

        [MaxLength(3000)]
        public string? Content { get; set; }
    }
}

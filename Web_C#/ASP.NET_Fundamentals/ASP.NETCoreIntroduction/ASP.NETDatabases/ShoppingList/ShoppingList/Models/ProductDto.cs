using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(81)]
        public string Name { get; set; } = null!;
    }
}

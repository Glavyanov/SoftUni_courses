using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Core.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; } = null!;

        [Required]
        public bool IsActive { get; set; } = true;

        public virtual ICollection<ProductNote> ProductNotes { get; set; } = new HashSet<ProductNote>();
    }
}

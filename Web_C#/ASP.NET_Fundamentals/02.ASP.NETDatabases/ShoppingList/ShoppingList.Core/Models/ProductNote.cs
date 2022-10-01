using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Core.Models
{
    public class ProductNote
    {
        [Key]
        public Guid Id { get; set; }

        public string? Content { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;

    }
}

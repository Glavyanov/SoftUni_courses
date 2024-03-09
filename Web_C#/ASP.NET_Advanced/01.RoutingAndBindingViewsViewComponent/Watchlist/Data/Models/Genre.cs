using System.ComponentModel.DataAnnotations;

namespace Watchlist.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; } = null!;
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Watchlist.Data.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Director { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Rating { get; set; }

        public int? GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre? Genre { get; set; }

        public List<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}

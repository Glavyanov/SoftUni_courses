using Library.Data.Entities;
using System.ComponentModel.DataAnnotations;
using static Library.Data.ValidationConstants.BookConstants;


namespace Library.Models
{
    public class BookAddViewModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength,
             ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength,
             ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
             ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), RatingMinRange, RatingMaxRange, ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}

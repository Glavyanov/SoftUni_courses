using System.ComponentModel.DataAnnotations;
using static ForumApp.Data.DataConstants.Post;

namespace ForumApp.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(TitleMaxLength, 
            MinimumLength = TitleMinLength, 
            ErrorMessage = "The field {0} must be a string with minimum length of {2} and maximum length of {1}")]
        public string Title { get; set; } = null!;

        [Display(Name = nameof(Content))]
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(ContentMaxLength,
            MinimumLength = ContentMinLength,
            ErrorMessage = "The field {0} must be a string with minimum length of {2} and maximum length of {1}")]
        public string Content { get; set; } = null!;
    }
}

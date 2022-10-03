namespace ForumApp.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static ForumApp.Data.DataConstants.Post;

    [Comment("Published posts")]
    public class Post
    {
        [Comment("Post identifier")]
        [Key]
        public int Id { get; init; }

        [Comment("Post title")]
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Comment("Post content")]
        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;

        [Comment("Marks entry to deleted")]
        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}

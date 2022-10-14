using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataValidation.BoardConstants;

namespace TaskBoardApp.Data.Entities
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BoardNameMaxLength)]
        public string Name { get; init; } = null!;

        public virtual ICollection<Task> Tasks { get; set; } = new HashSet<Task>();
    }
}

using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataValidation.TaskConstants;

namespace TaskBoardApp.Models.Tasks
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, 
            ErrorMessage ="{0}  should be at lest {2} characters long.")]
        public string Title { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
            ErrorMessage = "{0}  should be at lest {2} characters long.")]
        public string Description { get; set; }

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel>? Boards { get; set; }
    }
}

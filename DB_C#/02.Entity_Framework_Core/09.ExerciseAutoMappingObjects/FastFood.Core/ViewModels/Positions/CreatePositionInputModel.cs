using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Positions
{
    public class CreatePositionInputModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string PositionName { get; set; }
    }
}

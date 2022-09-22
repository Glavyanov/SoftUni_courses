using System.ComponentModel.DataAnnotations;

namespace ASPIntro.Models
{
    public class TestModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The field is required")]
        public string Product { get; set; } = null!;
    }
}

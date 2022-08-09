using System.ComponentModel.DataAnnotations;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeJsonDto
    {
        [Required]
        [MinLength(ValidationConstants.EmployeeUsernameMinLength)]
        [MaxLength(ValidationConstants.EmployeeUsernameMaxLength)]
        [RegularExpression(@"^[A-Za-z\d]{3,}$")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }
    }
}

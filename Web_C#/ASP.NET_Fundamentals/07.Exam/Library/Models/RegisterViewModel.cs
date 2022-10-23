using System.ComponentModel.DataAnnotations;
using static Library.Data.ValidationConstants.ApplicationUserConstants;

namespace Library.Models
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength,
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength,
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength,
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}

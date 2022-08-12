using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUserJsonDto
    {
        [Required]
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$")]
        public string FullName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Range(3,103)]
        public int Age { get; set; }

        [Required]
        [MinLength(1)]
        public ImportCardJsonDto[] Cards { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportCardJsonDto
    {
        [Required]
        [RegularExpression(@"^(\d{4}\s{1}){3}\d{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}$")]
        public string CVC { get; set; }

        [Required]
        public CardType? Type { get; set; }
    }
}

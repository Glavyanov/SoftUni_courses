using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportGamesJsonDto
    {
        [Required]
        public string Name { get; set; }

        [Range(typeof(decimal),"0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [MinLength(1)]
        public string[] Tags { get; set; }
    }
}

using Artillery.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class Country
    {
        public Country()
        {
            this.CountriesGuns = new HashSet<CountryGun>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CountryNameMaxLength)]
        public string CountryName { get; set; }

        public int ArmySize { get; set; }

        public virtual ICollection<CountryGun> CountriesGuns  { get; set; }
    }
}

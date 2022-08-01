using System.ComponentModel.DataAnnotations.Schema;

namespace Artillery.Data.Models
{
    public class CountryGun
    {
        [ForeignKey(nameof(Country))]
        public int CountryId  { get; set; }

        public virtual Country Country { get; set; }


        [ForeignKey(nameof(Gun))]
        public int GunId  { get; set; }

        public Gun Gun { get; set; }
    }
}

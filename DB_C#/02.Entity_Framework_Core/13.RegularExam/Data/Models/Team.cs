using Footballers.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.TeamsFootballers = new HashSet<TeamFootballer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidConstants.TeamNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ValidConstants.TeamNationalityMaxLength)]
        public string Nationality { get; set; }

        public int Trophies { get; set; }

        public virtual ICollection<TeamFootballer> TeamsFootballers  { get; set; }
    }
}

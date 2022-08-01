using Artillery.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class Shell
    {
        public Shell()
        {
            this.Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }

        public double ShellWeight { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ShellCaliberMaxLength)]
        public string Caliber { get; set; }

        public virtual ICollection<Gun> Guns { get; set; }
    }	
}

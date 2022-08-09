using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeisterMask.Common;

namespace TeisterMask.Data.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ProjectNameMaxLength)]
        public string Name { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime? DueDate { get; set; }

        public virtual ICollection<Task> Tasks { get; set; } = new HashSet<Task>();
    }
}

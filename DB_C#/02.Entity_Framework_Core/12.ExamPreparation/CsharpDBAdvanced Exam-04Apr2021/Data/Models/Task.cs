using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeisterMask.Common;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.TaskNameMaxLength)]
        public string Name{ get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime DueDate { get; set; }

        public ExecutionType ExecutionType { get; set; }

        public LabelType LabelType{ get; set; }

        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; } = new HashSet<EmployeeTask>();
    }
}

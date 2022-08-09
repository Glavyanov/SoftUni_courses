using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeisterMask.Common;

namespace TeisterMask.Data.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.EmployeeUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; } = new HashSet<EmployeeTask>();

    }
}

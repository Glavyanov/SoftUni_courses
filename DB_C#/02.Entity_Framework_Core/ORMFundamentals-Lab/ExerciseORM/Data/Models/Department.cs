using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseORM.Data.Models
{
    public class Department
    {
        public Department()
        {
            //Back up => improve performance
            this.Employees = new HashSet<Employee>();
        }

        [Key]
        public int DepartmentID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        //[ForeignKey(nameof(Employee))]
        //public int? ManagerID { get; set; }

        //public virtual Employee Employee { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } //Navigational properties are good to be virtual
    }
}

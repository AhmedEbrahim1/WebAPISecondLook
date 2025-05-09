using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPISecondLook.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string? Name { get; set; }
        [MaxLength(250)]
        public string? Address { get; set; }
        [Range(20,50)]
        public int? Age { get; set; }
        [Range(5000,60000)]
        public int Salary { get; set; }

        public virtual Department? Department { get; set; }
        [ForeignKey(nameof(Department))]
        public int? DeptId { get; set; }
    }
}

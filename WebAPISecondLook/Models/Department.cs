using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPISecondLook.Models
{
    [Table(nameof(Department))]
    public class Department
    {
        public int Id { get; set; }
        [MinLength(10)]
        [MaxLength(300)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Location { get; set; }
        //[JsonIgnore]
        public virtual ICollection<Employee>? Employees { set; get; }
    }
}

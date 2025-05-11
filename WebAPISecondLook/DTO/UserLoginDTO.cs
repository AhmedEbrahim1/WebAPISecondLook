using System.ComponentModel.DataAnnotations;

namespace WebAPISecondLook.DTO
{
    public class UserLoginDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

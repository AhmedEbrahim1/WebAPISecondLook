using System.ComponentModel.DataAnnotations;

namespace WebAPISecondLook.DTO
{
    public class UserRegisterDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace LN.Auth.API.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8}$", ErrorMessage = "Password must meet requirements")]
        public string? Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TaskTest.Models.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email address is required."), EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}

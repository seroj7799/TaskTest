using System.ComponentModel.DataAnnotations;

namespace TaskTest.Models.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Name is required."), MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Surname { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password), MaxLength(255)]
        public string Password { get; set; }

        [Required, Compare("Password"), DataType(DataType.Password), MaxLength(255)]
        public string ConfirmPassword { get; set; }

        [MaxLength(30)]
        public string? Phone { get; set; }
        [Required]
        public DateOnly BirthDay { get; set; }
        [Required, MaxLength(10)]
        public string Gender { get; set; }
        public int RoleId { get; set; } = 2;

        public DateTime CreatedAt = DateTime.Now;

        public DateTime UpdatedAt = DateTime.Now;

        public int IsDeleted = 0;

    }
}

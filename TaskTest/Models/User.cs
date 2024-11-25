using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTest.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Surname { get; set; }
        [Required, EmailAddress]
        public override string Email { get; set; }
        [MaxLength(255)]
        [DataType(DataType.Password)]
        public override string PasswordHash { get; set; }
        [MaxLength(30)]
        public string? Phone { get; set; }
        [Required]
        public DateOnly BirthDay { get; set; }
        [Required,MaxLength(10)]
        public string Gender { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [MaxLength(2)]
        public int IsDeleted { get; set; } = 0;


    }
}

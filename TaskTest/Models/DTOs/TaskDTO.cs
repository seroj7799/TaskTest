using System.ComponentModel.DataAnnotations;

namespace TaskTest.Models.DTOs
{
    public class TaskDTO
    {

        [Required, MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }
        [Required]
        public int Difficulty { get; set; }
         
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int IsDeleted { get; set; } = 0;

        public IEnumerable<IFormFile>? Images { get; set; }

    }
}

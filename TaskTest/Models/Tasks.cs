using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTest.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        [Required,MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        public User User { get; set; }

        [ForeignKey("Difficulty")]
        public int DifficultyId { get; set; }

        public Difficulty Difficulty { get; set; }

        public int CategoryId { get; set; }
        public TaskCategories Category { get; set; }
 
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set;} = DateTime.Now;

        [MaxLength(2)]
        public int IsDeleted { get; set; } = 0;

        public ICollection<Solutions> Solutions { get; set; }

        public ICollection<Tests> Tests { get; set; }

    }
}

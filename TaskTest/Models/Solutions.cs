using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTest.Models
{
    public class Solutions
    {
        public int Id { get; set; }
        public string TaskSolution { get; set; }

        [ForeignKey("ProgrammingLanguage")]
        public int ProgrammingLanguageId { get; set; }
        public ProgrammingLanguages Language { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }  // Required foreign key defaults to Restrict
        public Tasks Task {  get; set; }
        public User User { get; set; }
        public string SolutionTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
        public int IsDeleted { get; set; } = 0;

    }
}

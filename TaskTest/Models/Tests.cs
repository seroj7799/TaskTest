using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTest.Models
{
    public class Tests
    {
        public int Id { get; set; }
        public string Parameter { get; set; }
        public string Result { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }  // Required foreign key defaults to Restrict
        public Tasks Task { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("ProgrammingLanguages")]
        public int LanguageId { get; set; } 
        public ProgrammingLanguages Language { get; set; }
        public DateTime CreatedAt { get; set; } 

    }
}

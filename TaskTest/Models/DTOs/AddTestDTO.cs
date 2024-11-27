using System.ComponentModel.DataAnnotations;

namespace TaskTest.Models.DTOs
{
    public class AddTestDTO
    {
        [Required]
        [Range(1, int.MaxValue,ErrorMessage = "Chose the task.")]
        public int TaskId { get; set; }

        public IEnumerable<ProgrammingLanguages>? ProgrammingLanguages { get; set; }
        public IEnumerable<TaskTitleAndId>? Tasks { get; set; }
        [Required]
        public List<AddedTestDTO>? Test {  get; set; } 
    }

}


public class TaskTitleAndId
{
    public int Id { get; set; }
    public string Title { get; set; }
}

public class AddedTestDTO
{
    [Required(ErrorMessage = "Programming language is required!")]
    public string LanguageCode { get; set; }
    [Required(ErrorMessage = "Parameter is required!")]
    public string Parameter { get; set; }
    [Required(ErrorMessage = "Result is required!")]
    public string Result { get; set; }

}

namespace TaskTest.Models
{
    public class TaskImages
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public Tasks Task {  get; set; }
        public string URL { get; set; }
        public int IsDeleted {  get; set; } = 0;


    }
}

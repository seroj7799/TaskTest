using System.ComponentModel.DataAnnotations;

namespace TaskTest.Models
{
    public class Difficulty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        [MaxLength(2)]
        public int IsDeleted { get; set; } = 0;
    }
}

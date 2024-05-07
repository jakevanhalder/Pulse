using System.ComponentModel.DataAnnotations;

namespace PulseWeb.Models
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; } = false;

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
    }
}

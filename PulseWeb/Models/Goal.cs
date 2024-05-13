using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PulseWeb.Models
{
    public class Goal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Goal Name")]
        public string Title { get; set; }

        public string? Description { get; set; } = "No Description";

        [Required]
        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }

        [Required]
        public DateTime DueTime { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PulseWeb.Models
{
    public class BudgetItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}

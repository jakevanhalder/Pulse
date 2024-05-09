namespace PulseWeb.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Goal>? Goals { get; set; }
        public IEnumerable<ToDoItem>? ToDoItems { get; set; }
        public IEnumerable<BudgetItem>? BudgetItems { get; set; }
    }
}

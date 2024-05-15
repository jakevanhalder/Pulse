namespace PulseWeb.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Goal>? Goals { get; set; }
        public IEnumerable<ToDoItem>? ToDoItems { get; set; }
        public IEnumerable<BudgetItem>? BudgetItems { get; set; }
        public IEnumerable<UpcomingItem>? UpcomingItems { get; set; }

        // Properties to calculate the progress
        public double GoalsProgress => CalculateProgress(Goals?.Count() ?? 0, Goals?.Count(g => g.Status == Status.Completed) ?? 0);
        public double ToDosProgress => CalculateProgress(ToDoItems?.Count() ?? 0, ToDoItems?.Count(t => t.IsDone) ?? 0);
        public double BudgetsProgress => CalculateProgress(BudgetItems?.Count() ?? 0, BudgetItems?.Count(b => b.Amount <= 0) ?? 0); // Assuming budgets are completed if their amount is zero or less

        // Method to calculate progress percentage
        private double CalculateProgress(int totalItems, int completedItems)
        {
            if (totalItems == 0) return 0;
            return (double)completedItems / totalItems * 100;
        }
    }
}

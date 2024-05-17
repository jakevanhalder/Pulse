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
        public double ToDosProgress => CalculateProgress(ToDoItems?.Count() ?? 0, ToDoItems?.Count(t => t.Status == Status.Completed) ?? 0);
        public double BudgetsProgress => CalculateProgress(BudgetItems?.Count() ?? 0, BudgetItems?.Count(b => b.Amount <= 0) ?? 0); // Assuming budgets are completed if their amount is zero or less

        // Method to calculate progress percentage
        private double CalculateProgress(int totalItems, int completedItems)
        {
            if (totalItems == 0) return 0;
            return (double)completedItems / totalItems * 100;
        }

        // Properties to calculate the progress for the current month
        public int GoalsCompletedThisMonth => CalculateGoalsCompletedThisMonth();
        public int ToDosCompletedThisMonth => CalculateToDosCompletedThisMonth();
        public int BudgetsCompletedThisMonth => CalculateBudgetsCompletedThisMonth();

        // Method to calculate users completed goals, todos, and budgets for the month
        private int CalculateGoalsCompletedThisMonth()
        {
            var startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            // var endOfMonth = new DateTime()
            return Goals?.Count(g => g.Status == Status.Completed && g.DueDate >= startOfMonth && g.DueDate <= DateTime.Today) ?? 0;
        }

        private int CalculateToDosCompletedThisMonth()
        {
            var startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            return ToDoItems?.Count(t => t.Status == Status.Completed && t.DueDate >= startOfMonth && t.DueDate <= DateTime.Today) ?? 0;
        }

        private int CalculateBudgetsCompletedThisMonth()
        {
            var startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            return BudgetItems?.Count(b => b.Amount <= 0 && b.Date >= startOfMonth && b.Date <= DateTime.Today) ?? 0;
        }

        // Properties to calculate in progress, completed, and overdue items for the charts

        // Goals
        public int InProgressGoals => Goals?.Count(g => g.Status == Status.InProgress && g.DueDate >= DateTime.Today) ?? 0;
        public int CompletedGoals => Goals?.Count(g => g.Status == Status.Completed) ?? 0;
        public int OverdueGoals => Goals?.Count(g => g.Status != Status.Completed && g.DueDate < DateTime.Today) ?? 0;

        // ToDos
        public int InProgressToDos => ToDoItems?.Count(t => t.Status == Status.InProgress && t.DueDate >= DateTime.Today) ?? 0;
        public int CompletedToDos => ToDoItems?.Count(t => t.Status == Status.Completed) ?? 0;
        public int OverdueToDos => ToDoItems?.Count(t => t.Status != Status.Completed && t.DueDate < DateTime.Today) ?? 0;

        // Budgets
        public int InProgressBudgets => BudgetItems?.Count(b => b.Amount > 0 && b.Date >= DateTime.Today) ?? 0;
        public int CompletedBudgets => BudgetItems?.Count(b => b.Amount == 0) ?? 0;
        public int OverdueBudgets => BudgetItems?.Count(b => b.Amount > 0 && b.Date < DateTime.Today) ?? 0;
    }
}

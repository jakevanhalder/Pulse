using Microsoft.EntityFrameworkCore;
using PulseWeb.Models;

namespace PulseWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Goal> Goals { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<BudgetItem> Budgets { get; set; }
    }
}

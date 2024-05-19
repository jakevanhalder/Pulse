using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PulseWeb.Models;

namespace PulseWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Goal> Goals { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<BudgetItem> Budgets { get; set; }
    }
}

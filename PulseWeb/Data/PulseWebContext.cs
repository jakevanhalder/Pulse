using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PulseWeb.Models;

namespace PulseWeb.Data
{
    public class PulseWebContext : DbContext
    {
        public PulseWebContext (DbContextOptions<PulseWebContext> options)
            : base(options)
        {
        }

        public DbSet<PulseWeb.Models.ToDoItem> ToDoItem { get; set; } = default!;
    }
}

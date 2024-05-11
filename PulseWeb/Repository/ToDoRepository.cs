using PulseWeb.Data;
using PulseWeb.Models;
using PulseWeb.Repository.IRepository;

namespace PulseWeb.Repository
{
    public class ToDoRepository : Repository<ToDoItem>, IToDoRepository
    {
        private ApplicationDbContext _db;

        public ToDoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChangesAsync();
        }

        public void Update(ToDoItem todo)
        {
            _db.ToDoItems.Update(todo);
        }
    }
}

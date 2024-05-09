using PulseWeb.Models;

namespace PulseWeb.Repository.IRepository
{
    public interface IToDoRepository : IRepository<ToDoItem>
    {
        void Update(ToDoItem todo);
        void Save();
    }
}

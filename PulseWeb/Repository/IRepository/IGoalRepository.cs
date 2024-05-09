using PulseWeb.Models;

namespace PulseWeb.Repository.IRepository
{
    public interface IGoalRepository : IRepository<Goal>
    {
        void Update(Goal goal);
        void Save();
    }
}

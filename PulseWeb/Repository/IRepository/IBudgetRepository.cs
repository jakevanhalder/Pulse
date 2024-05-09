using PulseWeb.Models;

namespace PulseWeb.Repository.IRepository
{
    public interface IBudgetRepository : IRepository<BudgetItem>
    {
        void Update(BudgetItem budget);
        void Save();
    }
}

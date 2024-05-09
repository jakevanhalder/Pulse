using PulseWeb.Data;
using PulseWeb.Models;
using PulseWeb.Repository.IRepository;

namespace PulseWeb.Repository
{
    public class BudgetRepository : Repository<BudgetItem>, IBudgetRepository
    {
        private ApplicationDbContext _db;

        public BudgetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(BudgetItem budget)
        {
            _db.Budgets.Update(budget);
        }
    }
}

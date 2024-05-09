using PulseWeb.Data;
using PulseWeb.Models;
using PulseWeb.Repository.IRepository;
using System.Linq.Expressions;

namespace PulseWeb.Repository
{
    public class GoalRepository : Repository<Goal>, IGoalRepository
    {
        private ApplicationDbContext _db;

        public GoalRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Goal goal)
        {
            _db.Goals.Update(goal);
        }
    }
}

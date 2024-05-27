using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PulseWeb.Data;
using PulseWeb.Utility;

namespace PulseWeb.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Initialize()
        {
            // migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch(Exception ex) { }

            _db.Database.EnsureCreated();

            // create roles if they are not created
            if (!_roleManager.RoleExistsAsync(SD.Role_User).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User)).GetAwaiter().GetResult();
            }

            return;
        }
    }
}

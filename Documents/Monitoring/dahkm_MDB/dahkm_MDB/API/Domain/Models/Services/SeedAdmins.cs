using dahkm_MDB.API.Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dahkm_MDB.API.Domain.Models.Services
{
    public class SeedAdmins
    {
        private DahkmDbContext _db;
        private UserManager<ApplicationUser> _userMan;
        private RoleManager<IdentityRole> _roleMan;

        public SeedAdmins(DahkmDbContext db, UserManager<ApplicationUser> userMan, RoleManager<IdentityRole> roleMan)
        {
            _db = db;
            _userMan = userMan;
            _roleMan = roleMan;
        }

        public async Task SeedAdminsAsync()
        {
            _db.Database.EnsureCreated();
            if (!_db.Roles.Any(r => r.Name == "Administrator"))
            {
                await _roleMan.CreateAsync(new IdentityRole { Name = "Administrator" });
            }
            if(!_db.Users.Any(u => u.UserName == "admin@dahkm.com"))
            {
                var user = new ApplicationUser { Email = "admin@dahkm.com", UserName = "admin@dahkm.com" };
                await _userMan.CreateAsync(user, "Passw0rd!");
                await _userMan.AddToRoleAsync(user, "Administrator");
            }
        }
    }
}

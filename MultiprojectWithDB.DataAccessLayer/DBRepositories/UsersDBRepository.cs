using MultiprojectWithDB.DataAccessLayer.DBInterfaces;
using MultiprojectWithDB.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.DataAccessLayer.DBRepositories
{
    public class UsersDBRepository : IUsersDBRepository
    {
        private readonly MultiprojectDbContext _context;

        public UsersDBRepository(MultiprojectDbContext context)
        {
            context.Database.EnsureCreated();//jei yra sita eilute, is viso nereikia migraciju. DB kurse
            //kol nera duomenu (per swagger irasyt) tol DB nera
            _context = context;
        }
        // ==================== methods ====================

        public User GetUserByUsername(string username)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username);
        }

        public User GetUserById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }

        public void SaveUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }





    }
}

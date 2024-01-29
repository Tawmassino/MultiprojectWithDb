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
            context.Database.EnsureCreated();
            _context = context;
        }
        // ==================== methods ====================

        public User GetUser(string username)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username);
        }

        public void SaveUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }





    }
}

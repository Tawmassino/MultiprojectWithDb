using MultiprojectWithDB.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.DataAccessLayer.DBInterfaces
{
    public interface IUsersDBRepository
    {
        User GetUserByUsername(string username);
        User GetUserById(int userId);
        void SaveUser(User user);
    }
}

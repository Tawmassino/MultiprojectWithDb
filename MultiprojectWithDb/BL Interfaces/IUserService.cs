using MultiprojectWithDb.DTOs;
using MultiprojectWithDB.DataAccessLayer.Entities;

namespace MultiprojectWithDB.BusinessLogic.BL_Interfaces
{
    public interface IUserService //deti i API services
    {
        // dtos not found
        UserResponse Register(string username, string password);
        UserResponse Login(string username, string password, out string role);
        int GetCurrentUserId();
        //User GetUserById(int userId);
    }
}

using MultiprojectWithDb.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.BusinessLogic.BL_Interfaces
{
    public interface IUserService //deti i API services
    {
        // dtos not found
        UserResponseDTO Register(string username, string password);
        UserResponseDTO Login(string username, string password, out string role);
    }
}

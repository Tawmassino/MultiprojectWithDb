using MultiprojectWithDb.API.DTOs;
using MultiprojectWithDB.DataAccessLayer.Entities;
using MultiprojectWithDB.MAIN.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.BusinessLogic.BL_Interfaces
{
    public interface IUserMapper
    {
        User Map(UserCreateDTO dto);//create
        User Map(UserUpdateDTO dto);//update
        UserGetDTO Map(User user);//get


    }
}
